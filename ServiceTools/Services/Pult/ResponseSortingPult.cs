using ServiceTools.Core.Enums;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Modules.PultBlock.ViewModels;
using ServiceTools.Services.Pult.Interfaces;
using ServiceTools.Services.PultBlock.Interfaces.Helpers;
using ServiceTools.Services.PultBlock.Interfaces.Services;
using ServiceTools.Services.SerialPort.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceTools.Services.Pult
{
    /*
         * Формат сообщений
         * [0] = [адрес ведущего 1 байт]
         * [1] = [адрес ведомого 1 байт]
         * [2] = [команда 1 байт]
         * [3] = [длина сообщения 1 байт]
         * [4] = [данные 0-251 байт]
         * [5] = [CRC16-2 байта]
         */
    public class ResponseSortingPult : IResponseSortingPult
    {
        private readonly ViewPultViewModel _viewPultViewModel;
        private readonly IConstructorPult _constructorPult;
        private readonly IMessageQueue _messageQueue;
        private readonly IRequestsPult _requestsPult;

        public ResponseSortingPult(ViewPultViewModel viewPultViewModel,
            IConstructorPult constructorPult,
            IMessageQueue messageQueue,
            IRequestsPult requestsPult)
        {
            _viewPultViewModel = viewPultViewModel;
            _constructorPult = constructorPult;
            _messageQueue = messageQueue;
            _requestsPult = requestsPult;
        }

        /// <inheritdoc/>
        public void IncomingSorting(byte[] aData)
        {
            switch (aData[2])
            {
                case (byte)Command.GetStatus://0x01

                    break;
                case (byte)Command.GetSerialNumber://0x02 Ответ на запрос серийного номера
                    _viewPultViewModel.SerialNumber = string.Concat(_constructorPult.ExtractData(aData));
                    break;
                case (byte)Command.SetBacklightButtonInsect://0x16 Ответ на команду управления подсветкой кнопки Насекомые

                    break;
                case (byte)Command.SetBacklightButtonFoam://0x17 Ответ на команду управления подсветкой кнопки Пена

                    break;
                case (byte)Command.SetBacklightButtonFoamWater://0x18 Ответ на команду управления подсветкой кнопки Пена+вода

                    break;
                case (byte)Command.SetBacklightButtonHotWater://0x19 Ответ на команду управления подсветкой кнопки Горячая вода

                    break;
                case (byte)Command.SetBacklightButtonCoolWater://0x1A Ответ на команду управления подсветкой кнопки Холодная вода

                    break;
                case (byte)Command.SetBacklightButtonVosk://0x1B Ответ на команду управления подсветкой кнопки Воск

                    break;
                case (byte)Command.SetBacklightButtonOsmos://0x1C Ответ на команду управления подсветкой кнопки Осмос

                    break;
                case (byte)Command.SetBacklightButtonStop://0x1D Ответ на команду управления подсветкой кнопки Стоп

                    break;
                case (byte)Command.PushButtonInsect://0x1E Была нажата кнопка Средство от насекомых

                    break;
                case (byte)Command.PushButtonCollection://0x1F Была нажата кнопка Инкассация

                    break;
                case (byte)Command.SetDisplayNumber://0x20 Ответ на установку новых значений на дисплее

                    break;
                case (byte)Command.PushJettonChanel1://0x21 Был принят жетон по 1 каналу

                    break;
                case (byte)Command.PushJettonChanel2://0x22 Был принят жетон по 2 каналу

                    break;
                case (byte)Command.PushJettonChanel3://0x23 Был принят жетон по 3 каналу

                    break;
                case (byte)Command.PushButtonFoam://0x24 Была нажата кнопка Пена

                    break;
                case (byte)Command.PushButtonFoamWater://0x25 Была нажата кнопка Пена + вода

                    break;
                case(byte)Command.PushButtonHotWater://0x26 Была нажата кнопка Горячая вода

                    break;
                case (byte)Command.PushButtonCoolWater://0x27 Была нажата кнопка Холодная вода

                    break;
                case (byte)Command.PushButtonVosk://0x28 Была нажата кнопка Воск

                    break;
                case (byte)Command.PushButtonOsmos://0x29 Была нажата кнопка Осмос

                    break;
                case (byte)Command.PushButtonStop://0x2A Была нажата кнопка Стоп
                    _messageQueue.AddMessageToQueue(_requestsPult.SetBacklightButtonStop(State.On));
                    break;
                case (byte)Command.GetSoftwareVersion://0x2B Ответ на запрос версии программы
                    _viewPultViewModel.VersionSoftware = string.Format($"v{aData[4]}.{aData[5]}");
                    _messageQueue.AddMessageToQueue(_requestsPult.SetDisplayData(7171));
                    break;
                case (byte)Command.UidFlagReset://0x2C
                    _messageQueue.AddMessageToQueue(_requestsPult.GetSerialNumberDevice());
                    break;
                case (byte)Command.SoftwareFlagReset://0x2D
                    _messageQueue.AddMessageToQueue(_requestsPult.GetSoftwareVersion());
                    break;
                case (byte)Command.LockCoinAcceptor://0x2E Управление блокировкой монетоприемника

                    break;
                default:
                    break;
            }
        }
    }
}
