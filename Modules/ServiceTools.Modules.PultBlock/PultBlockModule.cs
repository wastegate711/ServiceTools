using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ServiceTools.Core;
using ServiceTools.Modules.PultBlock.Services;
using ServiceTools.Modules.PultBlock.Services.Interfaces;
using ServiceTools.Modules.PultBlock.ViewModels;
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
            _regionManager.RequestNavigate(RegionNames.PultBlockTab, "ViewPult");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ViewPultViewModel>();
            containerRegistry.Register<IRequestsPult, RequestsPult>();
            containerRegistry.RegisterForNavigation<ViewPult>();
        }
    }
}