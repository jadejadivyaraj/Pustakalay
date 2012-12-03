using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Pustakalay.BooksModule.ViewModels;
using Pustakalay.BooksModule.Views;
using Pustakalay.Data;
using Pustakalay.Infrastructure;

namespace Pustakalay.BooksModule
{
    public class BooksModule:IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public BooksModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }


        public void Initialize()
        {
            _container.RegisterType<MainContentView>();
            _container.RegisterType<IMainContentViewModel, MainContentViewModel>();
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof (MainContentView));
        }
    }
}
