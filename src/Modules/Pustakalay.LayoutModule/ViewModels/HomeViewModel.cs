using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Pustakalay.Infrastructure;

namespace Pustakalay.LayoutModule.ViewModels
{
    public class HomeViewModel : ViewModelBase,IHomeViewModel
    {
        private IRegionManager _regionManager;

        private IEventAggregator _aggregator;

        public HomeViewModel(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            BooksCommand = new DelegateCommand(OnBooksCommand, CanBooksCommandExecute);
            InventoryCommand = new DelegateCommand(OnInventoryCommand,CanInventoryCommandExecute);
            //NavigateCommand = new DelegateCommand<object>(OnNavigateCommand);
            //ApplicationCommands.NavagationCommand.RegisterCommand(NavigateCommand);
        }

     

        //public DelegateCommand<object> NavigateCommand { get; private set; }

        //private void OnNavigateCommand(object navigatePath)
        //{
        //    if (navigatePath!=null)
        //        _regionManager.RequestNavigate(RegionNames.ContentRegion,navigatePath.ToString());
        //}

        public DelegateCommand BooksCommand { get; set; }

        private bool CanBooksCommandExecute()
        {
            return true;
        }

        private void OnBooksCommand()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Publish(LayoutTypes.BooksLayout);
        }

        public DelegateCommand InventoryCommand { get; set; }

        private bool CanInventoryCommandExecute()
        {
            return true;
        }

        private void OnInventoryCommand()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Publish(LayoutTypes.PurchaseBooks);
        }

    }
}
