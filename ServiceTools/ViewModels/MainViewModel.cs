using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ServiceTools.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private string titleWindow = "";
        private string statusPort = "";

        public MainViewModel() : base()
        {
            titleWindow = "Service Tools";
            statusPort = "Порт:";
        }
        /// <summary>
        /// Заголовок главного окна
        /// </summary>
        public string TitleWindow
        {
            get
            {
                return titleWindow;
            }
            set
            {
                value = titleWindow;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// В статус баре, содержит состояние порта и его название
        /// </summary>
        public string StatusPort
        {
            get
            {
                return statusPort;
            }
            set
            {
                Set(ref statusPort, value);
            }
        }
    }
}
