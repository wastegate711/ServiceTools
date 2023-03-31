using System.Windows.Controls;
using Prism.Ioc;
using ServiceTools.Modules.ControlBlock.ViewModels;

namespace ServiceTools.Modules.ControlBlock.Views
{
    /// <summary>
    /// Interaction logic for ViewControlBlock.xaml
    /// </summary>
    public partial class ViewControlBlock : UserControl
    {
        public ViewControlBlock(IContainerProvider containerProvider)
        {
            InitializeComponent();
            DataContext = containerProvider.Resolve<ViewControlBlockViewModel>();
        }
    }
}