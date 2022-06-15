using Prism.Commands;
using Prism.Mvvm;
using SerialPortService.Abstractions;
using ServiceTools.Interfaces.Serial_port;
using ServiceTools.Services.SerialPort.Interfaces;

namespace ServiceTools.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IPortManager _portManager;
        private readonly IReceivedData _receivedData;

        public MainWindowViewModel(IPortManager portManager, IReceivedData receivedData)
        {
            _portManager = portManager;
            _receivedData = receivedData;
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
        }

        #endregion
    }
}
