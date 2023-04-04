using ServiceTools.Core.Enums;
using ServiceTools.Services.ControlBlock.Interfaces;

namespace ServiceTools.Services.ControlBlock
{
    /// <summary>
    /// Инструменты по обработке запросов.
    /// </summary>
    public class ResponseSortingControlBlock : IResponseSortingControlBlock
    {
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
        public ResponseSortingControlBlock()
        {
            
        }

        /// <inheritdoc />
        public void IncomingSorting(byte[] aData)
        {
            switch (aData[2])
            {
                case (byte)Command.GetStatus:
                    break;
                case (byte)Command.GetSerialNumber:
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
                    break;
            }
        }
    }
}
