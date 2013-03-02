using Pustakalay.Infrastructure;
using Pustakalay.LayoutModule.ViewModels;

namespace Pustakalay.LayoutModule.Views
{
    /// <summary>
    /// Interaction logic for HomeLayoutView.xaml
    /// </summary>
    public partial class HomeLayoutView : IHomeLayoutView
    {
        public HomeLayoutView(IHomeLayoutViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        #region Implementation of IView

        public IViewModel ViewModel
        {
            get { return (IHomeLayoutViewModel)DataContext; }
            set { DataContext = value; }
        }

        #endregion
    }
}
