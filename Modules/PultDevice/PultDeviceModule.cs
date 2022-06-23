using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PultDevice.Views;
using ServiceTools.Core;

namespace PultDevice
{
    public class PultDeviceModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public PultDeviceModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.PultBlockTab, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}