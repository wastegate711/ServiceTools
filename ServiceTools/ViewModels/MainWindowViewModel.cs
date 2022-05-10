using Prism.Commands;
using Prism.Mvvm;
using SerialPortService.Abstractions;

namespace ServiceTools.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            
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
            
        }

        #endregion
    }
}
