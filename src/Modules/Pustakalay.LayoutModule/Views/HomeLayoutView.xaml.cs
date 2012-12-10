﻿using System;
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
using Pustakalay.Infrastructure;
using Pustakalay.LayoutModule.ViewModels;

namespace Pustakalay.LayoutModule.Views
{
    /// <summary>
    /// Interaction logic for HomeLayoutView.xaml
    /// </summary>
    public partial class HomeLayoutView : UserControl,IHomeLayoutView
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
