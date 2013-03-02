using System.Windows;
using Pustakalay.BooksModule.ViewModels;
using Pustakalay.Infrastructure;

namespace Pustakalay.BooksModule.Views
{
    /// <summary>
    /// Interaction logic for MainContentView.xaml
    /// </summary>
    public partial class MainContentView : IMainContentView
    {
        public MainContentView(IMainContentViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IMainContentViewModel) DataContext; }
            set { DataContext = value; }
        }

        private void MovePrev(object sender, RoutedEventArgs e)
        {
            var avm = ViewModel as IMainContentViewModel;
            if (avm != null)
            {
                avm.Books.MoveCurrentToPrevious();
                if (avm.Books.IsCurrentBeforeFirst)
                    avm.Books.MoveCurrentToFirst();
            }
        }
        private void MoveNext(object sender, RoutedEventArgs e)
        {
            var avm = ViewModel as IMainContentViewModel;

            if (avm != null)
            {
                avm.Books.MoveCurrentToNext();
                if (avm.Books.IsCurrentAfterLast)
                    avm.Books.MoveCurrentToLast();
            }
        }
        private void MoveFirst(object sender, RoutedEventArgs e)
        {
            var avm = ViewModel as IMainContentViewModel;
            if (avm != null) avm.Books.MoveCurrentToFirst();
        }

        private void MoveLast(object sender, RoutedEventArgs e)
        {
            var avm = ViewModel as IMainContentViewModel;
            if (avm != null) avm.Books.MoveCurrentToLast();
        }
    }
}
