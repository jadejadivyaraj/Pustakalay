using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pustakalay.BooksModule.ViewModels;
using Pustakalay.Infrastructure;

namespace Pustakalay.BooksModule.Views
{
    /// <summary>
    /// Interaction logic for MainContentView.xaml
    /// </summary>
    public partial class MainContentView : UserControl,IMainContentView
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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
            
        //}
    }
}
