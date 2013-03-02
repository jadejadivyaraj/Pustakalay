using System;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Pustakalay.Infrastructure;
using Pustakalay.MembersModule.ViewModels;
using Pustakalay.MembersModule.Views;

namespace Pustakalay.MembersModule
{
    class MembersModule:IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _aggregator;

        public MembersModule(IRegionManager regionManager, IUnityContainer container, IEventAggregator aggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _aggregator = aggregator;
        }

        public void Initialize()
        {
            _container.RegisterType<object, MembersView>(typeof(MembersView).FullName);
            _container.RegisterType<IMembersViewModel, MembersViewModel>();
            _aggregator.GetEvent<LayoutChangeEvent>().Subscribe(OnLayoutChangeRequest,true);
        }

        private void OnLayoutChangeRequest(string obj)
        {
            if (LayoutTypes.MembersLayout.Equals(obj, StringComparison.Ordinal))
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, typeof (MembersView).FullName);
            }
        }
    }
}
