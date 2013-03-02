using Pustakalay.Infrastructure;
using Pustakalay.LayoutModule.ViewModels;

namespace Pustakalay.LayoutModule.Views
{
    /// <summary>
    /// Interaction logic for ToolbarView.xaml
    /// </summary>
    public partial class ToolbarView : IToolbarView
    {
        public ToolbarView (IToolbarViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IToolbarViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
