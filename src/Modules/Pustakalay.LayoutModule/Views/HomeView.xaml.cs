using Pustakalay.Infrastructure;
using Pustakalay.LayoutModule.ViewModels;

namespace Pustakalay.LayoutModule.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : IHomeView
    {
        public HomeView(IHomeViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        #region Implementation of IView

        public IViewModel ViewModel
        {
            get { return (IHomeViewModel)DataContext; }
            set { DataContext = value; }
        }

        #endregion
    }
}
