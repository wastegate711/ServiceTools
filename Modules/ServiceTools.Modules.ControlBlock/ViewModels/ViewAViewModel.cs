using Prism.Commands;
using Prism.Mvvm;
using ServiceTools.Core.Enums;
using ServiceTools.Core.Extensions;
using ServiceTools.Services.SerialPort.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ServiceTools.Modules.ControlBlock.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IMessageQueue _messageQueue;
        private readonly GlobalSettings _globalSettings;

        public ViewAViewModel(IMessageQueue messageQueue, GlobalSettings globalSettings)
        {
            _messageQueue = messageQueue;
            _globalSettings = globalSettings;
            DateTimeDevice = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }
        //Свойства

        #region Версия SW

        private string _versionSwPult;
        public string VersionSwPult
        {
            get => _versionSwPult;
            set => SetProperty(ref _versionSwPult, value);
        }

        #endregion

        #region Серийный номер

        private string _serialNumber = "123";
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
        public SolidColorBrush ValveOsmosBrush
        {
            get => _valveOsmosBrush;
            set => SetProperty(ref _valveOsmosBrush, value);
        }

        #endregion

        #region Цвет кнопки Холодная вода

        private SolidColorBrush _coolWaterBrush = Brushes.Red;
        public SolidColorBrush CoolWaterBrush
        {
            get => _coolWaterBrush;
            set => SetProperty(ref _coolWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Горячая вода

        private SolidColorBrush _hotWaterBrush = Brushes.Red;
        public SolidColorBrush HotWaterBrush
        {
            get => _hotWaterBrush;
            set => SetProperty(ref _hotWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки клапан Пена

        private SolidColorBrush _valveFoamBrush = Brushes.Red;
        public SolidColorBrush ValveFoamBrush
        {
            get => _valveFoamBrush;
            set => SetProperty(ref _valveFoamBrush, value);
        }

        #endregion

        #region Цвет кнопки клапан Воздух

        private SolidColorBrush _valveAirBrush = Brushes.Red;
        public SolidColorBrush ValveAirBrush
        {
            get => _valveAirBrush;
            set => SetProperty(ref _valveAirBrush, value);
        }

        #endregion

        #region Цвет кнопки клана Средство от насекомых

        private SolidColorBrush _valveInsectBrush = Brushes.Red;
        public SolidColorBrush ValveInsectBrush
        {
            get => _valveInsectBrush;
            set => SetProperty(ref _valveInsectBrush, value);
        }

        #endregion

        #region Цвет кнопки дозатора Пена

        private SolidColorBrush _dispenserFoamBrush = Brushes.Red;
        public SolidColorBrush DispenserFoamBrush
        {
            get => _dispenserFoamBrush;
            set => SetProperty(ref _dispenserFoamBrush, value);
        }

        #endregion

        #region Цвет кнопки дозатора Воск

        private SolidColorBrush _dispenserVoskBrush = Brushes.Red;
        public SolidColorBrush DispenserVoskBrush
        {
            get => _dispenserVoskBrush;
            set => SetProperty(ref _dispenserVoskBrush, value);
        }

        #endregion

        #region Цвет кнопки Клапан сброса

        private SolidColorBrush _valveDropBrush = Brushes.Red;
        public SolidColorBrush ValveDropBrush
        {
            get => _valveDropBrush;
            set => SetProperty(ref _valveDropBrush, value);
        }

        #endregion

        #region Цвет кнопки Запрос серийного номера устройства

        private SolidColorBrush _serialNumberBrush = Brushes.Yellow;
        public SolidColorBrush SerialNumberBrush
        {
            get => _serialNumberBrush;
            set => SetProperty(ref _serialNumberBrush, value);
        }

        #endregion
        //Команды

        #region Версия SW команда

        private DelegateCommand _versionSwCommand;
        public DelegateCommand VersionSwCommand =>
            _versionSwCommand ?? (_versionSwCommand = new DelegateCommand(ExecuteVersionSW));

        private void ExecuteVersionSW()
        {

        }

        #endregion

        #region Запрос серийного номера устройства

        private DelegateCommand _serialNumberCommand;
        public DelegateCommand SerialNumberCommand =>
            _serialNumberCommand ?? (_serialNumberCommand = new DelegateCommand(ExecuteSerialNumber));

        void ExecuteSerialNumber()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 0 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.GetSerialNumber));
        }

        #endregion

        #region Управление клапаном сброса

        private DelegateCommand _valveDropCommand;
        public DelegateCommand ValveDropCommand =>
            _valveDropCommand ?? (_valveDropCommand = new DelegateCommand(ExecuteValveDrop));

        void ExecuteValveDrop()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 1 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveDrop));
        }

        #endregion

        #region Управление дозатором Воск

        private DelegateCommand _dispenserVoskCommand;
        public DelegateCommand DispenserVoskCommand =>
            _dispenserVoskCommand ?? (_dispenserVoskCommand = new DelegateCommand(ExecuteDispenserVosk));

        private void ExecuteDispenserVosk()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 1 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetDispenserVosk));
        }

        #endregion

        #region Управление дозатором Пена

        private DelegateCommand _dispenserFoamCommand;
        public DelegateCommand DispenserFoamCommand =>
            _dispenserFoamCommand ?? (_dispenserFoamCommand = new DelegateCommand(ExecuteDispenserPena));

        private void ExecuteDispenserPena()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 1 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetDispenserFoam));
        }

        #endregion

        #region Управление клапаном Средство от насекомых

        private DelegateCommand _valveInsectCommand;
        public DelegateCommand ValveInsectCommand =>
            _valveInsectCommand ?? (_valveInsectCommand = new DelegateCommand(ExecuteValveInsect));

        void ExecuteValveInsect()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 1 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveInsect));
        }

        #endregion

        #region Управление клапаном Воздух

        private DelegateCommand _valveAirCommand;
        public DelegateCommand ValveAirCommand =>
            _valveAirCommand ?? (_valveAirCommand = new DelegateCommand(ExecuteValveAir));

        private void ExecuteValveAir()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 1 },
                _globalSettings.ControlBlockAddress,
                (byte)Command.SetValveAir));
        }

        #endregion

        #region Управление клапаном Пена

        private DelegateCommand _valveFoamCommand;
        public DelegateCommand ValveFoamCommand =>
            _valveFoamCommand ?? (_valveFoamCommand = new DelegateCommand(ExecuteValveFoamCommand));

        void ExecuteValveFoamCommand()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 1 }, _globalSettings.ControlBlockAddress, (byte)Command.SetValveFoam));
        }

        #endregion

        #region Управление клапаном Осмос

        private DelegateCommand _valveOsmosCommand;
        public DelegateCommand ValveOsmosCommand =>
            _valveOsmosCommand ?? (_valveOsmosCommand = new DelegateCommand(ExecuteValveOsmos));

        void ExecuteValveOsmos()
        {
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(
                new byte[] { 1 }, _globalSettings.ControlBlockAddress,
                ((byte)Command.SetValveOsmos)));
        }

        #endregion

        #region Управление клапаном Холодная вода

        private DelegateCommand _coolWaterCommand;
        public DelegateCommand CoolWaterCommand =>
            _coolWaterCommand ?? (_coolWaterCommand = new DelegateCommand(ExecuteCoolWater));

        void ExecuteCoolWater()
        {
            byte[] temp = new byte[1];
            temp[0] = 1;
            _messageQueue.AddMessageToQueue(_messageQueue.ConstructorCommand(temp, 2, 0x03));
        }

        #endregion

        #region Управление клапаном Горячая вода

        private DelegateCommand _valveHotWaterCommand;
        public DelegateCommand ValveHotWaterCommand =>
            _valveHotWaterCommand ?? (_valveHotWaterCommand = new DelegateCommand(ExecuteValveHotWater));

        void ExecuteValveHotWater()
        {
            byte[] temp = new byte[1];
            temp[0] = 0x01;
            _messageQueue
                .AddMessageToQueue(_messageQueue.ConstructorCommand(temp, _globalSettings.ControlBlockAddress, 0x04));
        }

        #endregion
    }
}
