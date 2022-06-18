using Prism.Commands;
using Prism.Mvvm;
using SerialPortService.Abstractions;
using ServiceTools.Interfaces.Serial_port;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Modules.PultBlock.ViewModels;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IPortManager _portManager;
        private readonly IReceivedData _receivedData;
        private readonly ViewPultViewModel _viewPultViewModel;
        private readonly ViewAViewModel _viewAViewModel;

        public MainWindowViewModel(IPortManager portManager, IReceivedData receivedData, ViewPultViewModel viewPultViewModel,
            ViewAViewModel viewAViewModel)
        {
            _portManager = portManager;
            _receivedData = receivedData;
            _viewPultViewModel = viewPultViewModel;
            _viewAViewModel = viewAViewModel;
        }

        #region Заголовок окна

        private string _title = "Prism Application";
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
            _portManager.Initialization();//инициализация таймеров и СОМ порта
            _receivedData.Initialization();
            _viewPultViewModel.SerialNumber = "asdasdasd";
            _viewAViewModel.SerialNumber = "123123123123123";
        }

        #endregion
    }
}
