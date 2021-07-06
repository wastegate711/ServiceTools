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

        public MainViewModel() : base()
        {
            titleWindow = "Service Tools";
        }

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
    }
}
