using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;



namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModelPrincipale viewModel = new ViewModelPrincipale();
            this.DataContext = viewModel;

            viewModel.ConfirmerPanierRequested += ViewModel_ConfirmerPanierRequested;
            viewModel.OuvrirPoliceWindowRequested += ViewModel_OuvrirPoliceWindowRequested;
        }

        private void ViewModel_ConfirmerPanierRequested(object sender, EventArgs e)
        {
            ConfirmerWindow confirmWindow = new ConfirmerWindow();
            confirmWindow.ShowDialog();
        }

        private void ViewModel_OuvrirPoliceWindowRequested(object sender, EventArgs e)
        {
            PoliceWindow policeWindow = new PoliceWindow();
            policeWindow.ShowDialog();
        }

    }
}
