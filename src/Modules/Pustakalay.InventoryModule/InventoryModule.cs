using System;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Pustakalay.Infrastructure;
using Pustakalay.InventoryModule.ViewModels;
using Pustakalay.InventoryModule.Views;

namespace Pustakalay.InventoryModule
{
    public class InventoryModule:IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _aggregator;

        public InventoryModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator aggregator)
        {
            _container = container;
            _aggregator = aggregator;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<object, InventoryView>(typeof(InventoryView).FullName);
            _container.RegisterType<IInventoryViewModel, InventoryViewModel>();
            _aggregator.GetEvent<LayoutChangeEvent>().Subscribe(OnLayoutChangeRequest,true);
            _container.RegisterType<IToolbarViewModel, ToolbarViewModel>();
            _container.RegisterType<object, ToolbarView>(typeof(ToolbarView).FullName);
            
        }

        private void OnLayoutChangeRequest(string obj)
        {
            if (LayoutTypes.InventoryLayout.Equals(obj, StringComparison.Ordinal))
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(InventoryView).FullName);
                _regionManager.RequestNavigate(RegionNames.ToolbarRegion, typeof(ToolbarView).FullName);
            }
               
        }
    }
}
