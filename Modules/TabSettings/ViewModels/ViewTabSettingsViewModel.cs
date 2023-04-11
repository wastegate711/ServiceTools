using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using SerialPortService.Services;

namespace TabSettings.ViewModels
{
    public class ViewTabSettingsViewModel : BindableBase
    {
        public ViewTabSettingsViewModel()
        {

        }

        // Свойства

        #region СОМ порты в системе

        private ObservableCollection<string> _serialPortInSystem = new ObservableCollection<string>();

        /// <summary>
        /// Содержит СОМ порты которые имеются в системе
        /// </summary>
        public ObservableCollection<string> SerialPortInSystem
        {
            get => _serialPortInSystem;
            set => SetProperty(ref _serialPortInSystem, value);
        }

        #endregion

        #region Выбранный порт для подключения

        private string _selectedSerialPort;

        /// <summary>
        /// Выделеный СОМ порт для подключения.
        /// </summary>
        public string SelectedSerialPort
        {
            get => _selectedSerialPort;
            set
            {
                SetProperty(ref _selectedSerialPort, value);
                SerialPortButtonConnection.RaiseCanExecuteChanged();
            }
        }

        #endregion

        // Команды

        #region Кнопка подключения к СОМ порту

        private DelegateCommand _serialPortButtonConnection;

        /// <summary>
        /// Подключается к COM порту.
        /// </summary>
        public DelegateCommand SerialPortButtonConnection =>
            _serialPortButtonConnection ??= new DelegateCommand(
                ExecuteSerialPortButtonConnection,
                CanExecuteSerialPortButtonConnection);

        private void ExecuteSerialPortButtonConnection()
        {
            if (SelectedSerialPort != null)
            {

            }
            else
            {
                MessageBox.Show("Внимание",
                    "СОМ порт не найден!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private bool CanExecuteSerialPortButtonConnection()
        {
            if (string.IsNullOrEmpty(SelectedSerialPort))
                return false;
            else
            {
                return true;
            }
        }

        #endregion

        #region Кнопка повторного запроса СОМ портов в системе

        private DelegateCommand _getAllSerialPort;

        /// <summary>
        /// Кнопка повторного запроса СОМ портов в системе
        /// </summary>
        public DelegateCommand GetAllSerialPort =>
            _getAllSerialPort ??= new DelegateCommand(ExecuteGetAllSerialPort);

        private void ExecuteGetAllSerialPort()
        {
            SerialPortInSystem.Clear();
            SerialPortInSystem.AddRange(Serial_Port.GetPortName());
        }

        #endregion
    }
}
