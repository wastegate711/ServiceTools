using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using SerialPortService.Services;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Modules.PultBlock.ViewModels;
using ServiceTools.Services.Serial_Port.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;
using TabSettings.ViewModels;

namespace ServiceTools.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IPortManager _portManager;
        private readonly IReceivedData _receivedData;
        private readonly ViewControlBlockViewModel _viewControlBlockViewModel;
        private readonly ViewPultViewModel _pultViewModel;
        private readonly ViewTabSettingsViewModel _tabSettingsViewModel;

        public MainWindowViewModel(
            IPortManager portManager,
            IReceivedData receivedData,
            ViewControlBlockViewModel controlBlockViewModel,
            ViewPultViewModel pultViewModel,
            ViewTabSettingsViewModel tabSettingsViewModel)
        {
            _portManager = portManager;
            _receivedData = receivedData;
            _viewControlBlockViewModel = controlBlockViewModel;
            _pultViewModel = pultViewModel;
            _tabSettingsViewModel = tabSettingsViewModel;
        }

        #region Заголовок окна

        private string _title = "Service tools";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion

        #region Команда инициализации
        //Обрабатывает событие загрузки окна.
        private DelegateCommand _initializeCommand;
        public DelegateCommand InitializeCommand =>
            _initializeCommand ??= new DelegateCommand(InitializeStartApp);

        private void InitializeStartApp()
        {
            //_portManager.Initialization();//инициализация таймеров и СОМ порта
            //_receivedData.Initialization();
            var t = Serial_Port.GetPortName();
            _tabSettingsViewModel.SerialPortInSystem.AddRange(Serial_Port.GetPortName());
        }

        #endregion

        #region Команда закрытия окна

        private DelegateCommand _unloadCommand;

        public DelegateCommand UnloadCommand =>
            _unloadCommand ??= new DelegateCommand(UnloadWindowExecution);

        private void UnloadWindowExecution()
        {
            App.Current.Shutdown();
        }

        #endregion
    }
}
