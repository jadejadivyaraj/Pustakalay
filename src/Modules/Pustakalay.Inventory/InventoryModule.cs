using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Pustakalay.Infrastructure;
using Pustakalay.Inventory.ViewModels;
using Pustakalay.Inventory.Views;

namespace Pustakalay.Inventory
{
    public class InventoryModule:IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IEventAggregator _aggregator;

        public InventoryModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator aggregator)
        {
            _container = container;
            _aggregator = aggregator;
            _regionManager = regionManager;
        }

        #region Implementation of IModule

        public void Initialize()
        {
            _container.RegisterType<object, PurchaseBooksView>(typeof(PurchaseBooksView).FullName);
            _container.RegisterType<IPurchaseBooksViewModel, PurchaseBooksViewModel>();
            _aggregator.GetEvent<LayoutChangeEvent>().Subscribe(OnLayoutChangeRequest);
        }

        private void OnLayoutChangeRequest(string obj)
        {
            if (LayoutTypes.PurchaseBooks.Equals(obj, StringComparison.Ordinal))
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof(PurchaseBooksView).FullName);
        }

        #endregion
    }
}
