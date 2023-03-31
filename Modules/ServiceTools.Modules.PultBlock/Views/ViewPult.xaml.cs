using System.Windows.Controls;
using Prism.Ioc;
using Prism.Regions;
using ServiceTools.Modules.PultBlock.ViewModels;

namespace ServiceTools.Modules.PultBlock.Views
{
    /// <summary>
    /// Interaction logic for ViewPult.xaml
    /// </summary>
    public partial class ViewPult
    {
        public ViewPult(IContainerProvider containerProvider)
        {
            InitializeComponent();
            DataContext = containerProvider.Resolve<ViewPultViewModel>();
        }
    }
}
