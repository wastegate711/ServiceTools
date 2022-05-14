using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ServiceTools.Core;
using ServiceTools.Modules.PultBlock.Views;

namespace ServiceTools.Modules.PultBlock
{
    public class PultBlockModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public PultBlockModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ControlBlockTab, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}