﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;


namespace Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ConfirmerWindow : Window
    {
        public ConfirmerWindow()
        {
            InitializeComponent();
            ViewModelPrincipale viewModel2 = new ViewModelPrincipale();
            this.DataContext = viewModel2;
            
            viewModel2.AnnulerConfirmerWindow += ViewModel_AnnulerConfirmerWindow;
        }

        private void ViewModel_AnnulerConfirmerWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
