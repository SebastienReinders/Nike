using Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class PoliceWindow : Window, INotifyPropertyChanged
    {
        // Propriété pour gestion Registry

        private ViewModelPrincipale viewModel4;

        //public double SliderValue { get; set; }

        private int _taille;

        public int Taille
        {
            get { return _taille; }
            set
            {
                if (_taille != value)
                {
                    _taille = value;
                    OnPropertyChanged();
                }
            }
        }

        public PoliceWindow()
        {
            InitializeComponent();
            viewModel4 = new ViewModelPrincipale();
            this.DataContext = viewModel4;

            viewModel4.ValiderPoliceWindowRequested += ViewModel_ValiderPoliceWindow;
            viewModel4.AnnulerConfirmerWindow += ViewModel_AnnulerConfirmerWindow;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ViewModel_ValiderPoliceWindow(object sender, EventArgs e)
        {
            Console.WriteLine("Bonsoir " + viewModel4.CheminAcces);

            this.Close();
            // Mettre à jour le registre
            MyAppParamManager paramManager = new MyAppParamManager();
            paramManager.LoadRegistryParameter();
            paramManager.CheminDossier = viewModel4.CheminAcces;
            paramManager.TaillePolice = Taille;
            paramManager.SaveRegistryParameter();
            
        }


        //fermeture fenetre options
        private void ViewModel_AnnulerConfirmerWindow(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
