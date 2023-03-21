using System.Linq;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Modules.PultBlock.ViewModels;
using ServiceTools.Services.Serial_Port.Interfaces;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IPortManager _portManager;
        private readonly IReceivedData _receivedData;
        private readonly ViewAViewModel _viewAViewModel;
        private readonly ViewPultViewModel _pultViewModel;

        public MainWindowViewModel(IPortManager portManager, IReceivedData receivedData,
            ViewAViewModel viewAViewModel, ViewPultViewModel pultViewModel)
        {
            _portManager = portManager;
            _receivedData = receivedData;
            _viewAViewModel = viewAViewModel;
            _pultViewModel = pultViewModel;
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
            _portManager.Initialization();//инициализация таймеров и СОМ порта
            _receivedData.Initialization();
            _pultViewModel.SerialNumber = "711345";
            string n = _pultViewModel.SerialNumber;
        }

        #endregion
    }
}
