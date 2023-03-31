using System.Windows;
using Prism.Ioc;
using ServiceTools.ViewModels;

namespace ServiceTools.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IContainerProvider containerProvider)
        {
            InitializeComponent();
            DataContext = containerProvider.Resolve<MainWindowViewModel>();
        }

        private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
