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
            _regionManager.RegisterViewWithRegion(RegionNames.TabSettings, typeof(ViewTabSettings));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewTabSettings>();
            containerRegistry.Register<ViewTabSettings>();
            containerRegistry.RegisterSingleton<ViewTabSettingsViewModel>();
        }
    }
}