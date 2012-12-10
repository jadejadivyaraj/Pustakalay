using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Pustakalay.Infrastructure;
using Pustakalay.LayoutModule.ViewModels;
using Pustakalay.LayoutModule.Views;

namespace Pustakalay.LayoutModule
{
    public  class LayoutModule:IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public LayoutModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<HomeLayoutView>();
            _container.RegisterType<IHomeLayoutViewModel,HomeLayoutViewModel>();
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(HomeLayoutView));
        }
    }
}
