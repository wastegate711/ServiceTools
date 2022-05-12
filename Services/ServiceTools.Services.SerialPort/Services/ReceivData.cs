using ServiceTools.Services.SerialPort.Interfaces;
using ServiceTools.Services.SerialPort.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTools.Services.SerialPort.Services
{
    public class ReceivData : IReceivData
    {
        /*
         * Формат сообщений
         * [адрес ведущего 1 байт][адрес ведомого 1 байт][команда 1 байт][длина сообщения 1 байт][данные 0-251 байт][CRC16-2 байта]
         */
        private bool accessFlag = false;
        private const byte controlBlockAddr = 0x01; //адрес блока управления
        private const byte pultBlockAddr = 0x02; //адрес пульта

        public ReceivData()
        {
            
        }
        
        ///<inheritdoc/>
        public void ReadData(byte[] buf)
        {
            if (buf.CompareCrc16())
            {
                switch (buf[1])//определяем от какого блока пришли данные.
                {
                    case controlBlockAddr:

                        break;
                    case pultBlockAddr:

                        break;
                }
            }
        }

    }
}
