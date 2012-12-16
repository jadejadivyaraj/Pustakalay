using System;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Pustakalay.BooksModule.ViewModels;
using Pustakalay.BooksModule.Views;
using Pustakalay.Infrastructure;

namespace Pustakalay.BooksModule
{
    public class BooksModule:IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IEventAggregator _aggregator;
        public BooksModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator aggregator)
        {
            _container = container;
            _aggregator = aggregator;
            _regionManager = regionManager;
        }


        public void Initialize()
        {
            _container.RegisterType<object, MainContentView>(typeof(MainContentView).FullName);
            _container.RegisterType<IMainContentViewModel, MainContentViewModel>();
            _aggregator.GetEvent<LayoutChangeEvent>().Subscribe(OnLayoutChangeRequest);
        }

        private void OnLayoutChangeRequest(string obj)
        {
            if (LayoutTypes.BooksLayout.Equals(obj, StringComparison.Ordinal)) 
                _regionManager.RequestNavigate(RegionNames.ContentRegion,typeof(MainContentView).FullName);
        }
    }
}
