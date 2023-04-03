using Prism.Commands;
using Prism.Mvvm;
using ServiceTools.Core.Enums;
using ServiceTools.Core.Extensions;
using ServiceTools.Services.SerialPort.Interfaces;
using System;
using System.Globalization;
using System.Windows.Media;
using ServiceTools.Modules.ControlBlock.Services.Interfaces;

namespace ServiceTools.Modules.ControlBlock.ViewModels
{
    public class ViewControlBlockViewModel : BindableBase
    {
        private readonly IMessageQueue _messageQueue;
        private readonly GlobalSettings _globalSettings;
        private readonly IMessageTools _messageTools;
        private readonly IRequestsControlBlock _requestsControlBlock;

        public ViewControlBlockViewModel(
            IMessageQueue messageQueue,
            GlobalSettings globalSettings,
            IMessageTools messageTools,
            IRequestsControlBlock requestsControlBlock)
        {
            _messageQueue = messageQueue;
            _globalSettings = globalSettings;
            _messageTools = messageTools;
            _requestsControlBlock = requestsControlBlock;
            DateTimeDevice = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }
        //Свойства

        #region Версия SW

        private string _versionSwPult = "*.*v";

        /// <summary>
        /// Версия программы устройства.
        /// </summary>
        public string VersionSwPult
        {
            get => _versionSwPult;
            set => SetProperty(ref _versionSwPult, value);
        }

        #endregion

        #region Серийный номер

        private string _serialNumber = "*****";

        /// <summary>
        /// Содержит UID устройства
        /// </summary>
        public string SerialNumber
        {
            get => _serialNumber;
            set => SetProperty(ref _serialNumber, value);
        }

        #endregion

        #region Дата и время

        private string _dateTimeDevice;

        /// <summary>
        /// Дата/Время установленые в блоке управления.
        /// </summary>
        public string DateTimeDevice
        {
            get => _dateTimeDevice;
            set => SetProperty(ref _dateTimeDevice, value);
        }

        #endregion

        #region Цвет кнопки Осмос

        private SolidColorBrush _valveOsmosBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки Осмос
        /// </summary>
        public SolidColorBrush ValveOsmosBrush
        {
            get => _valveOsmosBrush;
            set => SetProperty(ref _valveOsmosBrush, value);
        }

        #endregion

        #region Цвет кнопки Холодная вода

        private SolidColorBrush _coolWaterBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки Холодная вода.
        /// </summary>
        public SolidColorBrush CoolWaterBrush
        {
            get => _coolWaterBrush;
            set => SetProperty(ref _coolWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Горячая вода

        private SolidColorBrush _hotWaterBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки Горячая вода.
        /// </summary>
        public SolidColorBrush HotWaterBrush
        {
            get => _hotWaterBrush;
            set => SetProperty(ref _hotWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки клапан Пена

        private SolidColorBrush _valveFoamBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки клапан Пена.
        /// </summary>
        public SolidColorBrush ValveFoamBrush
        {
            get => _valveFoamBrush;
            set => SetProperty(ref _valveFoamBrush, value);
        }

        #endregion

        #region Цвет кнопки клапан Воздух

        private SolidColorBrush _valveAirBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки клапан Воздух.
        /// </summary>
        public SolidColorBrush ValveAirBrush
        {
            get => _valveAirBrush;
            set => SetProperty(ref _valveAirBrush, value);
        }

        #endregion

        #region Цвет кнопки клана Средство от насекомых

        private SolidColorBrush _valveInsectBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки клана Средство от насекомых.
        /// </summary>
        public SolidColorBrush ValveInsectBrush
        {
            get => _valveInsectBrush;
            set => SetProperty(ref _valveInsectBrush, value);
        }

        #endregion

        #region Цвет кнопки дозатора Пена

        private SolidColorBrush _dispenserFoamBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки дозатора Пена.
        /// </summary>
        public SolidColorBrush DispenserFoamBrush
        {
            get => _dispenserFoamBrush;
            set => SetProperty(ref _dispenserFoamBrush, value);
        }

        #endregion

        #region Цвет кнопки дозатора Воск

        private SolidColorBrush _dispenserVoskBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки дозатора Воск.
        /// </summary>
        public SolidColorBrush DispenserVoskBrush
        {
            get => _dispenserVoskBrush;
            set => SetProperty(ref _dispenserVoskBrush, value);
        }

        #endregion

        #region Цвет кнопки Клапан сброса

        private SolidColorBrush _valveDropBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки Клапан сброс.
        /// </summary>
        public SolidColorBrush ValveDropBrush
        {
            get => _valveDropBrush;
            set => SetProperty(ref _valveDropBrush, value);
        }

        #endregion

        #region Цвет кнопки Запрос серийного номера устройства

        private SolidColorBrush _serialNumberBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки Запрос серийного номера устройства.
        /// </summary>
        public SolidColorBrush SerialNumberBrush
        {
            get => _serialNumberBrush;
            set => SetProperty(ref _serialNumberBrush, value);
        }

        #endregion

        #region Цвет кнопки запроса версии программы устройства

        private SolidColorBrush _getSoftwareVersionBrush = Brushes.Red;

        /// <summary>
        /// Цвет кнопки запроса версии программы устройства
        /// </summary>
        public SolidColorBrush GetSoftwareVersionBrush
        {
            get => _getSoftwareVersionBrush;
            set => SetProperty(ref _getSoftwareVersionBrush, value);
        }

        #endregion

        //Команды

        #region Версия SoftWare команда

        private DelegateCommand _versionSwCommand;

        /// <summary>
        /// Версия программы устройства.
        /// </summary>
        public DelegateCommand VersionSoftwareCommand =>
            _versionSwCommand ??= new DelegateCommand(ExecuteVersionSoftWare);

        private void ExecuteVersionSoftWare()
        {
            GetSoftwareVersionBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.GetSoftwareVersion());
        }

        #endregion

        #region Запрос серийного номера устройства

        private DelegateCommand _serialNumberCommand;

        /// <summary>
        /// Запрос серийного номера устройства.
        /// </summary>
        public DelegateCommand SerialNumberCommand =>
            _serialNumberCommand ??= new DelegateCommand(ExecuteSerialNumber);

        private void ExecuteSerialNumber()
        {
            SerialNumberBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.GetSerialNumber());
        }

        #endregion

        #region Управление клапаном сброса

        private DelegateCommand _valveDropCommand;

        /// <summary>
        /// Управление состоянием клапана Сброса.
        /// </summary>
        public DelegateCommand ValveDropCommand =>
            _valveDropCommand ??= new DelegateCommand(ExecuteValveDrop);

        private void ExecuteValveDrop()
        {
            ValveDropBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetValveDrop(State.On));
        }

        #endregion

        #region Управление дозатором Воск

        private DelegateCommand _dispenserVoskCommand;

        /// <summary>
        /// Управление дозатором Воск.
        /// </summary>
        public DelegateCommand DispenserVoskCommand =>
            _dispenserVoskCommand ??= new DelegateCommand(ExecuteDispenserVosk);

        private void ExecuteDispenserVosk()
        {
            DispenserVoskBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetDispenserVosk(State.On));
        }

        #endregion

        #region Управление дозатором Пена

        private DelegateCommand _dispenserFoamCommand;

        /// <summary>
        /// Управление дозатором Пена.
        /// </summary>
        public DelegateCommand DispenserFoamCommand =>
            _dispenserFoamCommand ??= new DelegateCommand(ExecuteDispenserPena);

        private void ExecuteDispenserPena()
        {
            DispenserFoamBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetDispenserFoam(State.On));
        }

        #endregion

        #region Управление клапаном Средство от насекомых

        private DelegateCommand _valveInsectCommand;

        /// <summary>
        /// Управление клапаном Средство от насекомых.
        /// </summary>
        public DelegateCommand ValveInsectCommand =>
            _valveInsectCommand ??= new DelegateCommand(ExecuteValveInsect);

        private void ExecuteValveInsect()
        {
            ValveInsectBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetValveInsect(State.On));
        }

        #endregion

        #region Управление клапаном Воздух

        private DelegateCommand _valveAirCommand;

        /// <summary>
        /// Управление клапаном Воздух.
        /// </summary>
        public DelegateCommand ValveAirCommand =>
            _valveAirCommand ??= new DelegateCommand(ExecuteValveAir);

        private void ExecuteValveAir()
        {
            ValveAirBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetValveAir(State.On));
        }

        #endregion

        #region Управление клапаном Пена

        private DelegateCommand _valveFoamCommand;

        /// <summary>
        /// Управление клапаном Пена.
        /// </summary>
        public DelegateCommand ValveFoamCommand =>
            _valveFoamCommand ??= new DelegateCommand(ExecuteValveFoamCommand);

        private void ExecuteValveFoamCommand()
        {
            ValveFoamBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetValveFoam(State.On));
        }

        #endregion

        #region Управление клапаном Осмос

        private DelegateCommand _valveOsmosCommand;

        /// <summary>
        /// Управление клапаном Осмос.
        /// </summary>
        public DelegateCommand ValveOsmosCommand =>
            _valveOsmosCommand ??= new DelegateCommand(ExecuteValveOsmos);

        private void ExecuteValveOsmos()
        {
            ValveOsmosBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetValveOsmos(State.On));
        }

        #endregion

        #region Управление клапаном Холодная вода

        private DelegateCommand _coolWaterCommand;

        /// <summary>
        /// Управление клапаном Холодная вода.
        /// </summary>
        public DelegateCommand CoolWaterCommand =>
            _coolWaterCommand ??= new DelegateCommand(ExecuteCoolWater);

        private void ExecuteCoolWater()
        {
            CoolWaterBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetValveCoolWater(State.On));
        }

        #endregion

        #region Управление клапаном Горячая вода

        private DelegateCommand _valveHotWaterCommand;

        /// <summary>
        /// Управление клапаном Горячая вода.
        /// </summary>
        public DelegateCommand ValveHotWaterCommand =>
            _valveHotWaterCommand ??= new DelegateCommand(ExecuteValveHotWater);

        private void ExecuteValveHotWater()
        {
            HotWaterBrush = Brushes.Yellow;
            _messageQueue.AddMessageToQueue(_requestsControlBlock.SetValveHotWater(State.On));
        }

        #endregion
    }
}