using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ServiceTools.Core;
using ServiceTools.Modules.ControlBlock.ViewModels;
using ServiceTools.Modules.ControlBlock.Views;

namespace ServiceTools.Modules.ControlBlock
{
    public class ControlBlockModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ControlBlockModule(IRegionManager regionManager)
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
            containerRegistry.Register<ViewAViewModel>();
        }
    }
}