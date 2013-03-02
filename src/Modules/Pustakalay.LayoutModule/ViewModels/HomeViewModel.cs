using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Pustakalay.Infrastructure;

namespace Pustakalay.LayoutModule.ViewModels
{
    public class HomeViewModel : ViewModelBase,IHomeViewModel
    {
       // private IRegionManager _regionManager;

        private readonly IEventAggregator _aggregator;

        public HomeViewModel(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            BooksCommand = new DelegateCommand(OnBooksCommand, CanBooksCommandExecute);
            InventoryCommand = new DelegateCommand(OnInventoryCommand,CanInventoryCommandExecute);
            MembersCommand = new DelegateCommand(OnMembersCommand, CanMembersCommandExecute);
            //NavigateCommand = new DelegateCommand<object>(OnNavigateCommand);
            //ApplicationCommands.NavagationCommand.RegisterCommand(NavigateCommand);
        }

     

        //public DelegateCommand<object> NavigateCommand { get; private set; }

        //private void OnNavigateCommand(object navigatePath)
        //{
        //    if (navigatePath!=null)
        //        _regionManager.RequestNavigate(RegionNames.ContentRegion,navigatePath.ToString());
        //}

        #region BooksCommand
        
        public DelegateCommand BooksCommand { get; set; }

        private bool CanBooksCommandExecute()
        {
            return true;
        }

        private void OnBooksCommand()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Publish(LayoutTypes.BooksLayout);
        }

        #endregion BooksCommand

        #region InventoryCommand
        
        public DelegateCommand InventoryCommand { get; set; }

        private bool CanInventoryCommandExecute()
        {
            return true;
        }

        private void OnInventoryCommand()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Publish(LayoutTypes.InventoryLayout);
        }

        #endregion InventoryCommand

        #region MembersCommand

        public DelegateCommand MembersCommand { get; set; }

        private bool CanMembersCommandExecute()
        {
            return true;
        }

        private void OnMembersCommand()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Publish(LayoutTypes.MembersLayout);
        }

        #endregion MembersCommand
    }
}
