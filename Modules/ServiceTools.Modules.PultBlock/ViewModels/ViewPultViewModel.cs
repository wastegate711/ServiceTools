using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Media;
using ServiceTools.Core.Enums;
using ServiceTools.Modules.PultBlock.Services.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.Modules.PultBlock.ViewModels
{
    public class ViewPultViewModel : BindableBase
    {
        private readonly IMessageQueue _messageQueue;
        private readonly IRequestsPult _requestsPult;

        public ViewPultViewModel(IMessageQueue messageQueue, IRequestsPult requestsPult)
        {
            _messageQueue = messageQueue;
            _requestsPult = requestsPult;
        }

        // Свойства

        #region 1 Канал монетоприемника

        private string _coinAcceptor1;

        /// <summary>
        /// Выводит баланс средсв по 1 каналу монетоприемника.
        /// </summary>
        public string CoinAcceptorChanel1
        {
            get => _coinAcceptor1;
            set => SetProperty(ref _coinAcceptor1, value);
        }

        #endregion

        #region Стоимость 1 Канала монетоприемника

        private string _coinAcceptorChanel1Cost = "100";
        /// <summary>
        /// Задает значение сколько начислять по 1 каналу монетоприемника.
        /// </summary>
        public string CoinAcceptorChanel1Cost
        {
            get => _coinAcceptorChanel1Cost;
            set => SetProperty(ref _coinAcceptorChanel1Cost, value);
        }

        #endregion

        #region 2 Канал монетоприемника

        private string _coinAcceptorChanel2;
        /// <summary>
        /// Выводит баланс средсв по 2 каналу монетоприемника.
        /// </summary>
        public string CoinAcceptorChanel2
        {
            get => _coinAcceptorChanel2;
            set => SetProperty(ref _coinAcceptorChanel2, value);
        }

        #endregion

        #region 3 Канал монетоприемника

        private string _coinAcceptorChanel3;
        /// <summary>
        /// Выводит баланс средсв по 3 каналу монетоприемника.
        /// </summary>
        public string CoinAcceptorChanel3
        {
            get => _coinAcceptorChanel3;
            set => SetProperty(ref _coinAcceptorChanel3, value);
        }

        #endregion

        #region Серийный номер

        private string _serialNumber = "0";
        /// <summary>
        /// Содержит серийный номер устройства.
        /// </summary>
        public string SerialNumber
        {
            get => _serialNumber;
            set => SetProperty(ref _serialNumber, value);
        }

        #endregion

        #region Серийный номер цвет кнопки

        private SolidColorBrush _serialNumberBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки запроса серийного номера устройства.
        /// </summary>
        public SolidColorBrush SerialNumberBrush
        {
            get => _serialNumberBrush;
            set => SetProperty(ref _serialNumberBrush, value);
        }

        #endregion

        #region Версия программы

        private string _softWareVersion = "v0.0";
        /// <summary>
        /// Содержит версию программы устройства.
        /// </summary>
        public string VersionSoftware
        {
            get => _softWareVersion;
            set => SetProperty(ref _softWareVersion, value);
        }

        #endregion

        #region Цвет кнопки версия программы

        private SolidColorBrush _versionSoftwareBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки запроса версии программы устройства.
        /// </summary>
        public SolidColorBrush VersionSoftwareBrush
        {
            get => _versionSoftwareBrush;
            set => SetProperty(ref _versionSoftwareBrush, value);
        }

        #endregion

        #region Цвет кнопки подсветка средство от насекомых

        private SolidColorBrush _backlightInsectBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки подсветка средство от насекомых.
        /// </summary>
        public SolidColorBrush BacklightInsectBrush
        {
            get => _backlightInsectBrush;
            set => SetProperty(ref _backlightInsectBrush, value);
        }

        #endregion

        #region Цвет кнопки подсветка Пена

        private SolidColorBrush _backlightFoamBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки отправки запроса включения функции Пена.
        /// </summary>
        public SolidColorBrush BacklightFoamBrush
        {
            get => _backlightFoamBrush;
            set => SetProperty(ref _backlightFoamBrush, value);
        }

        #endregion

        #region Цвет кнопки подсветка Пена + вода

        private SolidColorBrush _backlightFoamWaterBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки отправки запроса включения функции ПЕна + Вода
        /// </summary>
        public SolidColorBrush BacklightFoamWaterBrush
        {
            get => _backlightFoamWaterBrush;
            set => SetProperty(ref _backlightFoamWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Горячая вода

        private SolidColorBrush _backlightHotWaterBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки отправки запроса включения функции Горячая вода.
        /// </summary>
        public SolidColorBrush BacklightHotWaterBrush
        {
            get => _backlightHotWaterBrush;
            set => SetProperty(ref _backlightHotWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Холодная вода

        private SolidColorBrush _backlightCoolWaterBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки отправки запроса включения функции Холодная вода.
        /// </summary>
        public SolidColorBrush BacklightCoolWaterBrush
        {
            get => _backlightCoolWaterBrush;
            set => SetProperty(ref _backlightCoolWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Воск

        private SolidColorBrush _backlightVoskBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки отправки запроса включения функции Воск
        /// </summary>
        public SolidColorBrush BacklightVoskBrush
        {
            get => _backlightVoskBrush;
            set => SetProperty(ref _backlightVoskBrush, value);
        }

        #endregion

        #region Цвет кнопки Осмос

        private SolidColorBrush _backlightOsmosBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки отправки запроса включения функции Осмос.
        /// </summary>
        public SolidColorBrush BacklightOsmosBrush
        {
            get => _backlightOsmosBrush;
            set => SetProperty(ref _backlightOsmosBrush, value);
        }

        #endregion

        #region Цвет кнопки Стоп

        private SolidColorBrush _backlightStopBrush = Brushes.Red;
        /// <summary>
        /// Цвет кнопки отправки запроса включения функции Стоп
        /// </summary>
        public SolidColorBrush BacklightStopBrush
        {
            get => _backlightStopBrush;
            set => SetProperty(ref _backlightStopBrush, value);
        }

        #endregion

        #region Отображение баланса на дисплее

        private string _displayValue = "";
        /// <summary>
        /// Вывод значения на дисплее пульта.
        /// </summary>
        public string DisplayValue
        {
            get => _displayValue;
            set => SetProperty(ref _displayValue, value);
        }

        #endregion

        // Команды

        #region Начисление баланса для монетоприемника 1 канал

        private DelegateCommand _coinAcceptorChanel1Command;
        /// <summary>
        /// Начисление баланса для монетоприемника 1 канал
        /// </summary>
        public DelegateCommand CoinAcceptorChanel1Command =>
            _coinAcceptorChanel1Command ??
            (_coinAcceptorChanel1Command = new DelegateCommand(ExecuteCoinAcceptorChanel1));

        private void ExecuteCoinAcceptorChanel1()
        {
        }

        #endregion

        #region Начисление баланса для монетоприемника 2 канал
        /// <summary>
        /// Начисление баланса для монетоприемника 2 канал
        /// </summary>
        private DelegateCommand _coinAcceptorChanel2Command;

        public DelegateCommand CoinAcceptorChanel2Command =>
            _coinAcceptorChanel2Command ??
            (_coinAcceptorChanel2Command = new DelegateCommand(ExecuteCoinAcceptorChanel2));

        private void ExecuteCoinAcceptorChanel2()
        {
        }

        #endregion

        #region Начисление баланса для монетоприемника 3 канал

        private DelegateCommand _coinAcceptorChanel3Command;
        /// <summary>
        /// Начисление баланса для монетоприемника 3 канал
        /// </summary>
        public DelegateCommand CoinAcceptorChanel3Command =>
            _coinAcceptorChanel3Command ??
            (_coinAcceptorChanel3Command = new DelegateCommand(ExecuteCoinAcceptorChanel3));

        private void ExecuteCoinAcceptorChanel3()
        {
        }

        #endregion

        #region Запрос серийного номера

        private DelegateCommand _serialNumberCommand;
        /// <summary>
        /// Запрос серийного номера устройства.
        /// </summary>
        public DelegateCommand SerialNumberCommand =>
            _serialNumberCommand ?? (_serialNumberCommand = new DelegateCommand(ExecuteSerialNumber));

        private void ExecuteSerialNumber()
        {
            SerialNumberBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsPult.GetSerialNumberDevice());
        }

        #endregion

        #region Запрос версии программы

        private DelegateCommand _versionSoftwareCommand;
        /// <summary>
        /// Запрос версии программы устройства.
        /// </summary>
        public DelegateCommand VersionSoftwareCommand =>
            _versionSoftwareCommand ?? (_versionSoftwareCommand = new DelegateCommand(ExecuteVersionSoftware));

        private void ExecuteVersionSoftware()
        {
            VersionSoftwareBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsPult.GetSoftwareVersion());
        }

        #endregion

        #region Включение подстветки кнопки Средство от насекомых

        private DelegateCommand _backlightInsectCommand;
        /// <summary>
        /// Включение подстветки кнопки Средство от насекомых.
        /// </summary>
        public DelegateCommand BacklightInsectCommand =>
            _backlightInsectCommand ?? (_backlightInsectCommand = new DelegateCommand(ExecuteBacklightInsect));

        private void ExecuteBacklightInsect()
        {
        }

        #endregion

        #region Включение подсветки кнопки Пена

        private DelegateCommand _backlightFoamCommand;
        /// <summary>
        /// Включение подсветки кнопки Пена.
        /// </summary>
        public DelegateCommand BacklightFoamCommand =>
            _backlightFoamCommand ?? (_backlightFoamCommand = new DelegateCommand(ExecuteBacklightFoam));

        private void ExecuteBacklightFoam()
        {
        }

        #endregion

        #region Включение подсветки кнопки Пена + вода

        private DelegateCommand _backlightFoamWaterCommand;
        /// <summary>
        /// Включение подсветки кнопки Пена + вода.
        /// </summary>
        public DelegateCommand BacklightFoamWaterCommand =>
            _backlightFoamWaterCommand ?? (_backlightFoamWaterCommand = new DelegateCommand(ExecuteBacklightFoamWater));

        private void ExecuteBacklightFoamWater()
        {
        }

        #endregion

        #region Включение подсветки кнопки Горячая вода

        private DelegateCommand _backlightHotWaterCommand;
        /// <summary>
        /// Включение подсветки кнопки Горячая вода.
        /// </summary>
        public DelegateCommand BacklightHotWaterCommand =>
            _backlightHotWaterCommand ?? (_backlightHotWaterCommand = new DelegateCommand(ExecuteBacklightHotWater));

        private void ExecuteBacklightHotWater()
        {
        }

        #endregion

        #region Включение подсветки кнопки Холодная вода

        private DelegateCommand _backlightCoolWaterCommand;
        /// <summary>
        /// Включение подсветки кнопки Холодная вода.
        /// </summary>
        public DelegateCommand BacklightCoolWaterCommand =>
            _backlightCoolWaterCommand ?? (_backlightCoolWaterCommand = new DelegateCommand(ExecuteBacklightCoolWater));

        private void ExecuteBacklightCoolWater()
        {
        }

        #endregion

        #region Включение подсветки кнопки Воск

        private DelegateCommand _backlightVoskCommand;
        /// <summary>
        /// Включение подсветки кнопки Воск.
        /// </summary>
        public DelegateCommand BacklightVoskCommand =>
            _backlightVoskCommand ?? (_backlightVoskCommand = new DelegateCommand(ExecuteBacklightVosk));

        private void ExecuteBacklightVosk()
        {
            BacklightVoskBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsPult.SetBacklightButtonVosk(State.On));
        }

        #endregion

        #region Включение подсветки кнопки Осммос

        private DelegateCommand _backlightOsmosCommand;
        /// <summary>
        /// Включение подсветки кнопки Осммос.
        /// </summary>
        public DelegateCommand BacklightOsmosCommand =>
            _backlightOsmosCommand ?? (_backlightOsmosCommand = new DelegateCommand(ExecuteBacklightOsmos));

        private void ExecuteBacklightOsmos()
        {
        }

        #endregion

        #region Включение подсветки кнопки Стоп

        private DelegateCommand _backlightStopCommand;
        /// <summary>
        /// Включение подсветки кнопки Стоп.
        /// </summary>
        public DelegateCommand BacklightStopCommand =>
            _backlightStopCommand ?? (_backlightStopCommand = new DelegateCommand(ExecuteBacklightStop));

        private void ExecuteBacklightStop()
        {
        }

        #endregion

        #region Установка значения на дисплее

        private DelegateCommand _displayValueCommand;
        /// <summary>
        /// Установка значения на дисплее устройства.
        /// </summary>
        public DelegateCommand DisplayValueCommand =>
            _displayValueCommand ?? (_displayValueCommand = new DelegateCommand(ExecuteDisplayValue));

        private void ExecuteDisplayValue()
        {
        }

        #endregion
    }
}