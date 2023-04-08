using System.Windows.Controls;
using Prism.Ioc;
using TabSettings.ViewModels;

namespace TabSettings.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewTabSettings : UserControl
    {
        public ViewTabSettings(IContainerProvider containerProvider)
        {
            InitializeComponent();
            DataContext = containerProvider.Resolve<ViewTabSettingsViewModel>();
        }
    }
}
