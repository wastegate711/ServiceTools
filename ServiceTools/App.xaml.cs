using Prism.Ioc;
using Prism.Modularity;
using ServiceTools.Modules.ControlBlock;
using ServiceTools.Views;
using System.Windows;
using ServiceTools.Modules.PultBlock;

namespace ServiceTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ControlBlockModule>();
            moduleCatalog.AddModule<PultBlockModule>();
        }
    }
}
