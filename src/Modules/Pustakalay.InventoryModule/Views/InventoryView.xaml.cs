using System.Windows;
using Pustakalay.Infrastructure;
using Pustakalay.InventoryModule.ViewModels;

namespace Pustakalay.InventoryModule.Views
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : IInventoryView
    {
        public InventoryView(IInventoryViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IInventoryViewModel)DataContext; }
            set { DataContext = value; }
        }


        private void MoveFirst(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IInventoryViewModel;
            if (vm != null) vm.Books.MoveCurrentToFirst();
        }

        private void MovePrev(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IInventoryViewModel;
            if (vm != null)
            {
                vm.Books.MoveCurrentToPrevious();
                if (vm.Books.IsCurrentBeforeFirst)
                    vm.Books.MoveCurrentToFirst();
            }
        }

        private void MoveNext(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IInventoryViewModel;
            if (vm != null)
            {
                vm.Books.MoveCurrentToNext();
                if (vm.Books.IsCurrentAfterLast)
                    vm.Books.MoveCurrentToLast();
            }
        }

        private void MoveLast(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IInventoryViewModel;
            if (vm != null) vm.Books.MoveCurrentToLast();
        }
    }
}
