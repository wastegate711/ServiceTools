using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ServiceTools.Modules.PultBlock.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public ViewAViewModel()
        {
            
        }

        // Свойства

        #region Серийный номер

        private string _serialNumber = "123";
        public string SerialNumber
        {
            get => _serialNumber;
            set => SetProperty(ref _serialNumber, value);
        }                   

        #endregion

        #region Серийный номер цвет кнопки

        private SolidColorBrush _serialNumberBrush = Brushes.Red;
        public SolidColorBrush SerialNumberBrush
        {
            get => _serialNumberBrush;
            set => SetProperty(ref _serialNumberBrush, value);
        }

        #endregion

        #region Версия программы

        private string _softWareVersion = "0.0";
        public string VersionSoftware
        {
            get => _softWareVersion;
            set => SetProperty(ref _softWareVersion, value);
        }

        #endregion

        #region Цвет кнопки версия программы

        private SolidColorBrush _versionSoftwareBrush = Brushes.Red;
        public SolidColorBrush VersionSoftwareBrush
        {
            get => _versionSoftwareBrush;
            set => SetProperty(ref _versionSoftwareBrush, value);
        }

        #endregion

        #region Цвет кнопки подсветка средство от насекомых

        private SolidColorBrush _backlightInsectBrush = Brushes.Red;
        public SolidColorBrush BacklightInsectBrush
        {
            get => _backlightInsectBrush;
            set => SetProperty(ref _backlightInsectBrush, value);
        }

        #endregion

        #region Цвет кнопки подсветка Пена

        private SolidColorBrush _backlightFoamBrush = Brushes.Red;
        public SolidColorBrush BacklightFoamBrush
        {
            get => _backlightFoamBrush;
            set => SetProperty(ref _backlightFoamBrush, value);
        }

        #endregion

        #region Цвет кнопки подсветка Пена + вода

        private SolidColorBrush _backlightFoamWaterBrush = Brushes.Red;
        public SolidColorBrush BacklightFoamWaterBrush
        {
            get => _backlightFoamWaterBrush;
            set => SetProperty(ref _backlightFoamWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Горячая вода

        private SolidColorBrush _backlightHotWaterBrush = Brushes.Red;
        public SolidColorBrush BacklightHotWaterBrush
        {
            get => _backlightHotWaterBrush;
            set => SetProperty(ref _backlightHotWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Холодная вода

        private SolidColorBrush _backlightCoolWaterBrush = Brushes.Red;
        public SolidColorBrush BacklightCoolWaterBrush
        {
            get => _backlightCoolWaterBrush;
            set => SetProperty(ref _backlightCoolWaterBrush, value);
        }

        #endregion

        #region Цвет кнопки Воск

        private SolidColorBrush _backlightVoskBrush = Brushes.Red;
        public SolidColorBrush BacklightVoskBrush
        {
            get => _backlightVoskBrush;
            set => SetProperty(ref _backlightVoskBrush, value);
        }

        #endregion

        #region Цвет кнопки Осмос

        private SolidColorBrush _backlightOsmosBrush = Brushes.Red;
        public SolidColorBrush BacklightOsmosBrush
        {
            get => _backlightOsmosBrush;
            set => SetProperty(ref _backlightOsmosBrush, value);
        }

        #endregion

        #region Цвет кнопки Стоп

        private SolidColorBrush _backlightStopBrush = Brushes.Red;
        public SolidColorBrush BacklightStopBrush
        {
            get => _backlightStopBrush;
            set => SetProperty(ref _backlightStopBrush, value);
        }

        #endregion

        #region Отображение баланса на дисплее

        private string _displayValue = "";
        public string DisplayValue
        {
            get => _displayValue;
            set => SetProperty(ref _displayValue, value);
        }

        #endregion

        // Команды

        #region Запрос серийного номера

        private DelegateCommand _serialNumberCommand;
        public DelegateCommand SerialNumberCommand =>
            _serialNumberCommand ?? (_serialNumberCommand = new DelegateCommand(ExecuteSerialNumber));

        private void ExecuteSerialNumber()
        {

        }

        #endregion

        #region Запрос версии программы

        private DelegateCommand _versionSoftwareCommand;
        public DelegateCommand VersionSoftwareCommand =>
            _versionSoftwareCommand ?? (_versionSoftwareCommand = new DelegateCommand(ExecuteVersionSoftware));

        private void ExecuteVersionSoftware()
        {

        }

        #endregion

        #region Включение подстветки кнопки Средство от насекомых

        private DelegateCommand _backlightInsectCommand;
        public DelegateCommand BacklightInsectCommand =>
            _backlightInsectCommand ?? (_backlightInsectCommand = new DelegateCommand(ExecuteBacklightInsect));

        private void ExecuteBacklightInsect()
        {

        }

        #endregion

        #region Включение подсветки кнопки Пена

        private DelegateCommand _backlightFoamCommand;
        public DelegateCommand BacklightFoamCommand =>
            _backlightFoamCommand ?? (_backlightFoamCommand = new DelegateCommand(ExecuteBacklightFoam));

        private void ExecuteBacklightFoam()
        {

        }

        #endregion

        #region Включение подсветки кнопки Пена + вода

        private DelegateCommand _backlightFoamWaterCommand;
        public DelegateCommand BacklightFoamWaterCommand =>
            _backlightFoamWaterCommand ?? (_backlightFoamWaterCommand = new DelegateCommand(ExecuteBacklightFoamWater));

        private void ExecuteBacklightFoamWater()
        {

        }

        #endregion

        #region Включение подсветки кнопки Горячая вода

        private DelegateCommand _backlightHotWaterCommand;
        public DelegateCommand BacklightHotWaterCommand =>
            _backlightHotWaterCommand ?? (_backlightHotWaterCommand = new DelegateCommand(ExecuteBacklightHotWater));

        private void ExecuteBacklightHotWater()
        {

        }

        #endregion

        #region Включение подсветки кнопки Холодная вода

        private DelegateCommand _backlightCoolWaterCommand;
        public DelegateCommand BacklightCoolWaterCommand =>
            _backlightCoolWaterCommand ?? (_backlightCoolWaterCommand = new DelegateCommand(ExecuteBacklightCoolWater));

        private void ExecuteBacklightCoolWater()
        {

        }

        #endregion

        #region Включение подсветки кнопки Воск

        private DelegateCommand _backlightVoskCommand;
        public DelegateCommand BacklightVoskCommand =>
            _backlightVoskCommand ?? (_backlightVoskCommand = new DelegateCommand(ExecuteBacklightVosk));

        private void ExecuteBacklightVosk()
        {

        }

        #endregion

        #region Включение подсветки кнопки Осммос

        private DelegateCommand _backlightOsmosCommand;
        public DelegateCommand BacklightOsmosCommand =>
            _backlightOsmosCommand ?? (_backlightOsmosCommand = new DelegateCommand(ExecuteBacklightOsmos));

        private void ExecuteBacklightOsmos()
        {

        }

        #endregion

        #region Включение подсветки кнопки Стоп

        private DelegateCommand _backlightStopCommand;
        public DelegateCommand BacklightStopCommand =>
            _backlightStopCommand ?? (_backlightStopCommand = new DelegateCommand(ExecuteBacklightStop));

        private void ExecuteBacklightStop()
        {

        }

        #endregion

        #region Установка значения на дисплее

        private DelegateCommand _displayValueCommand;
        public DelegateCommand DisplayValueCommand =>
            _displayValueCommand ?? (_displayValueCommand = new DelegateCommand(ExecuteDisplayValue));

        private void ExecuteDisplayValue()
        {

        }

        #endregion
    }
}
