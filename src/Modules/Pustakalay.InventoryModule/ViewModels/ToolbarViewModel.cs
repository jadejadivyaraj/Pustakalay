using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Pustakalay.Infrastructure;

namespace Pustakalay.InventoryModule.ViewModels
{
    class ToolbarViewModel : ViewModelBase, IToolbarViewModel
    {

        private readonly IEventAggregator _aggregator;

        public ToolbarViewModel(IEventAggregator aggregator)
        {
            HomeCommand = new DelegateCommand(OnHome, CanHome);
            _aggregator = aggregator;
        }

        #region HomeCommand

        public DelegateCommand HomeCommand { get; set; }

        private void OnHome()
        {
            _aggregator.GetEvent<LayoutChangeEvent>().Publish(LayoutTypes.HomeLayout);
        }

        private bool CanHome()
        {
            return true;
        }

        #endregion
    }
}
