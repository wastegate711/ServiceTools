using ServiceTools.Services.Pult.Interfaces;
using ServiceTools.Services.Serial_Port.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.SerialPort.Tools;
using System.Diagnostics;
using ServiceTools.Services.ControlBlock.Interfaces;

namespace ServiceTools.Services.Serial_Port
{
    /*
         * Формат сообщений
         * [0] = [адрес ведущего 1 байт]
         * [1] = [адрес ведомого 1 байт]
         * [2] = [команда 1 байт]
         * [3] = [Номер сообщения 1 байт]
         * [4] = [длина сообщения 1 байт]
         * [5] = [данные 0-251 байт]
         * [^2] = [CRC16-2 байта]
         * [^1] = [CRC16-2 байта]
         */
    public class ReceivedData : IReceivedData
    {
        private readonly IPortManager _portManager;
        private readonly IResponseSortingPult _responseSortingPult;
        private readonly IResponseSortingControlBlock _responseSortingControlBlock;
        private const byte ControlBlockAddr = 0x02; //адрес блока управления
        private const byte PultBlockAddr = 0x03; //адрес пульта

        public ReceivedData(IPortManager portManager,
            IResponseSortingPult responseSortingPult,
            IResponseSortingControlBlock responseSortingControlBlock)
        {
            _portManager = portManager;
            _responseSortingPult = responseSortingPult;
            _responseSortingControlBlock = responseSortingControlBlock;
        }

        public void Initialization()
        {
            _portManager.ReceivedData += PortManager_ReceivedData;
        }

        private void PortManager_ReceivedData(byte[] aData)
        {
            if (aData.CompareCrc16())
            {
                switch (aData[1]) //определяем от какого блока пришли данные.
                {
                    case ControlBlockAddr:
                        Debug.Write("Входящие данные БУ<--\t");

                        foreach (byte item in aData)
                        {
                            Debug.Write(item.ToString("X2") + " ");
                        }

                        Debug.WriteLine("");
                        _responseSortingControlBlock.IncomingSorting(aData);

                        break;
                    case PultBlockAddr:
                        Debug.Write("Входящие данные БП<--\t");

                        foreach (byte item in aData)
                        {
                            Debug.Write(item.ToString("X2") + " ");
                        }

                        Debug.WriteLine("");

                        _responseSortingPult.IncomingSorting(aData);
                        break;
                }
            }
            else
            {
                if (aData.Length >= 3)
                {
                    Debug.WriteLine("Ошибка CRC16 Отправитель={0} Команда={1}", aData[1], aData[2]);
                }
                else
                {
                    Debug.WriteLine("Ошибка входной массив короче 3 символов.");
                }
            }
        }
    }
}