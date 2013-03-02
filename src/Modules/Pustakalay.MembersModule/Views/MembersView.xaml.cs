using System.Windows;
using Pustakalay.Infrastructure;
using Pustakalay.MembersModule.ViewModels;

namespace Pustakalay.MembersModule.Views
{
    /// <summary>
    /// Interaction logic for MembersView.xaml
    /// </summary>
    public partial class MembersView : IMembersView
    {
        public MembersView(IMembersViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IMembersViewModel)DataContext; }
            set { DataContext = value; }
        }

        private void MoveFirst(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IMembersViewModel;
            if (vm != null) vm.Members.MoveCurrentToFirst();
        }

        private void MovePrev(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IMembersViewModel;
            if (vm != null)
            {
                vm.Members.MoveCurrentToPrevious();
                if (vm.Members.IsCurrentBeforeFirst)
                    vm.Members.MoveCurrentToFirst();
            }
        }

        private void MoveNext(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IMembersViewModel;
            if (vm != null)
            {
                vm.Members.MoveCurrentToNext();
                if (vm.Members.IsCurrentAfterLast)
                    vm.Members.MoveCurrentToLast();
            }
        }

        private void MoveLast(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as IMembersViewModel;
            if (vm != null) vm.Members.MoveCurrentToLast();
        }
    }
}
