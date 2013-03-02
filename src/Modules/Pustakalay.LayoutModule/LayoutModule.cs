using System;
using Microsoft.Practices.Prism.Events;
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
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _aggregator;

        public LayoutModule(IRegionManager regionManager, IUnityContainer container, IEventAggregator aggregator)
        {
            _regionManager = regionManager;
            _container = container;
            _aggregator = aggregator;
        }

        public void Initialize()
        {
            RegisterTypes();
            SubscribeEvents();
            _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(HomeView).FullName);
        }

        private void SubscribeEvents()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Subscribe(OnLayoutChangeRequest, true);
        }

        private void RegisterTypes()
        {
            _container.RegisterType<HomeLayoutView>();
            _container.RegisterType<IHomeLayoutViewModel, HomeLayoutViewModel>();
            _container.RegisterType<object, HomeView>(typeof (HomeView).FullName);
            _container.RegisterType<IHomeViewModel, HomeViewModel>();
            _container.RegisterType<IToolbarViewModel, ToolbarViewModel>();
            _container.RegisterType<object, ToolbarView>(typeof (ToolbarView).FullName);
        }

        private void OnLayoutChangeRequest(string obj)
        {
            if (LayoutTypes.HomeLayout.Equals(obj, StringComparison.Ordinal))
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(HomeView).FullName);
                foreach (var view in _regionManager.Regions[RegionNames.ToolbarRegion].Views)
                {
                    _regionManager.Regions[RegionNames.ToolbarRegion].Remove(view);
                }
            }

        }
    }
}
