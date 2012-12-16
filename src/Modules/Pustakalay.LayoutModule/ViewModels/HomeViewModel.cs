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

        public DelegateCommand<object> NavigateCommand { get; private set; }

        public HomeViewModel(IEventAggregator aggregator )
        {
            _aggregator = aggregator;
            BooksCommand = new DelegateCommand(OnBooksCommand, CanBooksCommandExecute);
            NavigateCommand = new DelegateCommand<object>(OnNavigateCommand);
            ApplicationCommands.NavagationCommand.RegisterCommand(NavigateCommand);
        }

        private void OnNavigateCommand(object navigatePath)
        {
            if (navigatePath!=null)
                _regionManager.RequestNavigate(RegionNames.ContentRegion,navigatePath.ToString());
        }

        private void OnBooksCommand()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Publish(LayoutTypes.BooksLayout);
        }

        private bool CanBooksCommandExecute()
        {
            return true;
        }

        public DelegateCommand BooksCommand { get; set; }

        private bool _books;
        
        public bool Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged("Books");
            }
        }
    }
}
