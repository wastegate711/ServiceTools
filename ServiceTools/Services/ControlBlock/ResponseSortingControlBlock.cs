using System.Windows.Media;
using ServiceTools.Core.Enums;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Services.ControlBlock.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.Services.ControlBlock
{
    /// <summary>
    /// Инструменты по обработке запросов.
    /// </summary>
    public class ResponseSortingControlBlock : IResponseSortingControlBlock
    {
        private readonly ViewControlBlockViewModel _controlBlockViewModel;
        private readonly IMessageTools _messageTools;

        /**
         * * Формат сообщений
         * [0] = [адрес ведущего 1 байт]
         * [1] = [адрес ведомого 1 байт]
         * [2] = [команда 1 байт]
         * [3] = [Номер сообщения 1 байт]
         * [4] = [длина сообщения 1 байт]
         * [5] = [данные 0-251 байт]
         * [^2] = [CRC16-2 байта]
         * [^1] = [CRC16-2 байта]
         */
        public ResponseSortingControlBlock(
            ViewControlBlockViewModel controlBlockViewModel,
            IMessageTools messageTools)
        {
            _controlBlockViewModel = controlBlockViewModel;
            _messageTools = messageTools;
        }

        /// <inheritdoc />
        public void IncomingSorting(byte[] aData)
        {
            switch (aData[2])
            {
                case (byte)Command.GetStatus:
                    
                    break;
                case (byte)Command.GetSerialNumber:
                    _controlBlockViewModel.SerialNumberBrush = Brushes.Green;
                    _controlBlockViewModel.SerialNumber = string.Concat(_messageTools.ExtractData(aData));
                    break;
                case (byte)Command.SetValveCoolWater:
                    break;
                case (byte)Command.SetValveHotWater:
                    break;
                case (byte)Command.SetValveOsmos:
                    break;
                case (byte)Command.SetValveFoam:
                    break;
                case (byte)Command.SetValveAir:
                    break;
                case (byte)Command.SetValveInsect:
                    break;
                case (byte)Command.SetValveDrop:
                    break;
                case (byte)Command.SetDispenserFoam:
                    break;
                case (byte)Command.SetDispenserVosk:
                    break;
                case (byte)Command.GetSensorStream:
                    
                    break;
                case (byte)Command.GetValveCoolWater:
                    break;
                case (byte)Command.GetValveHotWater:
                    break;
                case (byte)Command.GetValveOsmos:
                    break;
                case (byte)Command.GetValveFoam:
                    break;
                case (byte)Command.GetValveAir:
                    break;
                case (byte)Command.GetValveInsect:
                    break;
                case (byte)Command.GetValveDrop:
                    break;
                case (byte)Command.GetDispenserFoam:
                    break;
                case (byte)Command.GetDispenserVosk:
                    break;
                case (byte)Command.GetSoftwareVersion:
                    _controlBlockViewModel.GetSoftwareVersionBrush = Brushes.Green;
                    _controlBlockViewModel.VersionSwPult = string.Format($"v{aData[5]}.{aData[6]}");
                    break;
            }
        }
    }
}
