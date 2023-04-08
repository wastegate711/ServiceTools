using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ServiceTools.Core;
using TabSettings.ViewModels;
using TabSettings.Views;

namespace TabSettings
{
    [Module(ModuleName = "TabSettings", OnDemand = true)]
    public class TabSettingsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public TabSettingsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.TabSettings, "TabSettings");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ViewTabSettings>();
            containerRegistry.Register<ViewTabSettingsViewModel>();
        }
    }
}