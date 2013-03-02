using Pustakalay.Infrastructure;
using Pustakalay.LayoutModule.ViewModels;

namespace Pustakalay.LayoutModule.Views
{
    /// <summary>
    /// Interaction logic for ExpanderNavigation.xaml
    /// </summary>
    public partial class ExpanderNavigation : IExpanderNavigation
    {
        public ExpanderNavigation(IExpanderNavigationViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IExpanderNavigationViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
