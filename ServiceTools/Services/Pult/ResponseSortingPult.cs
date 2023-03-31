using System.Windows.Media;
using ServiceTools.Core.Enums;
using ServiceTools.Modules.PultBlock.Services.Interfaces;
using ServiceTools.Modules.PultBlock.ViewModels;
using ServiceTools.Services.Pult.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.Services.Pult
{
    /*
     * Индикатор статуса
     * Красный - нет данных
     * Желтый - Был отправлен запрос
     * Зеленый - После отправки запроса получен ответ
     * Голубой - У исполнительного устройства изменилось состояниее 
     * 
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
    /// <summary>
    /// Сортирует ответы от Пульта.
    /// </summary>
    public class ResponseSortingPult : IResponseSortingPult
    {
        private readonly ViewPultViewModel _viewPultViewModel;
        private readonly IMessageTools _messageTools;
        private readonly IMessageQueue _messageQueue;
        private readonly IRequestsPult _requestsPult;
        byte[] tempMessage = new byte[255];

        public ResponseSortingPult(
            ViewPultViewModel viewPultViewModel,
            IMessageTools messageTools,
            IMessageQueue messageQueue,
            IRequestsPult requestsPult)
        {
            _viewPultViewModel = viewPultViewModel;
            _messageTools = messageTools;
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
                    _viewPultViewModel.SerialNumber = string.Concat(_messageTools.ExtractData(aData));
                    _viewPultViewModel.SerialNumberBrush = Brushes.Green;
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
                case (byte)Command.PushButtonHotWater://0x26 Была нажата кнопка Горячая вода

                    break;
                case (byte)Command.PushButtonCoolWater://0x27 Была нажата кнопка Холодная вода

                    break;
                case (byte)Command.PushButtonVosk://0x28 Была нажата кнопка Воск

                    break;
                case (byte)Command.PushButtonOsmos://0x29 Была нажата кнопка Осмос

                    break;
                case (byte)Command.PushButtonStop://0x2A Была нажата кнопка Стоп
                    _viewPultViewModel.BacklightStopBrush = Brushes.Blue;
                    _messageQueue.AddMessageToQueue(_requestsPult.SetBacklightButtonStop(State.On));
                    break;
                case (byte)Command.GetSoftwareVersion://0x2B Ответ на запрос версии программы
                    _viewPultViewModel.VersionSoftware = string.Format($"v{aData[5]}.{aData[6]}");
                    _viewPultViewModel.VersionSoftwareBrush = Brushes.Green;
                    _messageQueue.AddMessageToQueue(_requestsPult.SetDisplayData(7171));
                    break;
                case (byte)Command.UidFlagReset://0x2C
                    _messageQueue.AddMessageToQueue(_requestsPult.GetSerialNumberDevice());
                    _viewPultViewModel.SerialNumberBrush = Brushes.Yellow;
                    break;
                case (byte)Command.SoftwareFlagReset://0x2D
                    _messageQueue.AddMessageToQueue(_requestsPult.GetSoftwareVersion());
                    _viewPultViewModel.VersionSoftwareBrush = Brushes.Yellow;
                    break;
                case (byte)Command.LockCoinAcceptor://0x2E Управление блокировкой монетоприемника

                    break;
                //0x2F Запрос состояния подсветки кнопки Средство от насекомых
                case (byte)Command.GetBacklightButtonInsect: 
                    break;
                //0x30 Запрос состояния подсветки кнопки Пена
                case (byte)Command.GetBacklightButtonFoam:
                    break;
                //0x31 Запрос состояния подсветки кнопки Пена + вода
                case (byte)Command.GetBacklightButtonFoamWater:
                    break;
                //0x32 Запрос состояния подсветки кнопки Горячая вода
                case (byte)Command.GetBacklightButtonHotWater:
                    break;
                //0x33 Запрос состояния подсветки кнопки Холодная вода
                case (byte)Command.GetBacklightButtonCoolWater:
                    break;
                //0x34 Запрос состояния подсветки кнопки Воск
                case (byte)Command.GetBacklightButtonVosk:
                    break;
                //0x35 Запрос состояния подсветки кнопки Осмос
                case (byte)Command.GetBacklightButtonOsmos:
                    break;
                //0x36 Запрос состояния подсветки кнопки Стоп
                case (byte)Command.GetBacklightButtonStop:
                    break;
                default:
                    // TODO - Добавить логирование неизвестной команды
                    break;
            }
        }
    }
}
