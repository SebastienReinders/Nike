using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Modele;
using ViewModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;


namespace ViewModel
{
    public class ViewModelPrincipale : ViewModelBase, INotifyPropertyChanged
    {
        // Liste des modèles de chaussures
        private ObservableCollection<Article> _articles;
        public ObservableCollection<Article> Articles
        {

            get { return _articles; }
            set
            {
                _articles = value;
                RaisePropertyChanged("Articles");
            }
        }
        private Client _client;

        public Client Client
        {
            get { return _client; }
            set { _client = value;}
        }

        // Pour le formulaire 

        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public int Age { get; set; }
        public string GSM { get; set; }

        // Modèle de chaussure sélectionné dans la ComboBox
        private Article _selectedArticle;
        public Article SelectedArticle
        {
            get { return _selectedArticle; }
            set
            {
                _selectedArticle = value;
                RaisePropertyChanged("SelectedArticle");
                RaisePropertyChanged("InfosArticle");
                AjouterAuPanierCommand.RaiseCanExecuteChanged();
            }
        }

        // Propriété calculée pour afficher les informations de l'article sélectionné
        public string InfosArticle
        {
            get
            {
                if (SelectedArticle != null)
                {
                    return $"Nom du modèle : {SelectedArticle.Designation}\nPrix : {SelectedArticle.Prix}€";
                }
                else
                {
                    return "Sélectionnez un modèle de chaussure";
                }
            }
        }

        // Liste des articles dans le panier
        private ObservableCollection<Article> _articlesPanier = new ObservableCollection<Article>();
        public ObservableCollection<Article> ArticlesPanier
        {
            get { return _articlesPanier; }
            set
            {
                _articlesPanier = value;
                RaisePropertyChanged(nameof(ArticlesPanier));
                RaisePropertyChanged(nameof(TotalAPayer));
            }
        }

        // Prix total à payer pour les articles dans le panier
        private double _totalAPayer;
        public double TotalAPayer
        {
            get { return ArticlesPanier.Sum(article => article.Prix); }
            set { _totalAPayer = value; }
        }




        //Propriété pour gestion chemin registry

        public string CheminAcces { get; set; }






        public RelayCommand AjouterAuPanierCommand { get; set; }
        public RelayCommand ViderPanierCommand { get; set; }
        public RelayCommand ConfirmerPanierCommand { get; set; }
        public RelayCommand AnnulerCommand { get; private set; }
        public RelayCommand OuvrirPoliceWindowCommand { get;  set; }
        public RelayCommand EnvoyerCommande { get; set; }

        public RelayCommand ValiderCommand { get; set; }





        public event EventHandler ConfirmerPanierRequested;
        public event EventHandler AnnulerConfirmerWindow;
        public event EventHandler OuvrirPoliceWindowRequested;
        public event EventHandler ValiderPoliceWindowRequested;

        public ViewModelPrincipale()
        {
            // Initialisation de la liste des articles avec des exemples
            Articles = new ObservableCollection<Article>
            {
                //ici on appelera une methode load qui chargera les articles depuis un fichier
                new Article("Air Jordan", 1, 145, "Images/jordan.png"),
                new Article("Air Max    ", 1, 135, "Images/airmax.png"),
                new Article("Air Max90", 1, 125, "Images/airmax90.png"),
                new Article("Air Force  ", 1, 115, "Images/airforce.png")
            };

            // Commande pour ajouter un article au panier
            AjouterAuPanierCommand = new RelayCommand(
                () => AjouterAuPanier(),
                () => CanAjouterAuPanier());

            // Commande pour vider le panier
            ViderPanierCommand = new RelayCommand(
                () => ViderPanier());

            // Commande pour confirmer le panier
            ConfirmerPanierCommand = new RelayCommand(
                () => ConfirmerPanier());

            // Initialiser la commande Annuler
            AnnulerCommand = new RelayCommand(Annuler);

            EnvoyerCommande = new RelayCommand(EnregistrerCommande);



            // Commande qui ouvre la fenetre pour regler la police

            OuvrirPoliceWindowCommand = new RelayCommand(
                () => OuvrirPoliceWindow());


            ValiderCommand = new RelayCommand(
                () => ValiderPoliceWindow());



        }

        // Méthode qui retourne vrai si on peut ajouter un article au panier
        public bool CanAjouterAuPanier()
        {
            return SelectedArticle != null;
        }

        // Méthode appelée lorsque l'utilisateur clique sur "Ajouter au panier"
        public void AjouterAuPanier()
        {
            if (SelectedArticle != null)
            {
                //  ArticlesPanier.Add(SelectedArticle);
                ArticlesPanier.Add(new Article
                {
                    Designation = SelectedArticle.Designation,
                    Quantite = SelectedArticle.Quantite,
                    Prix = SelectedArticle.Prix,
                    ImagePath = SelectedArticle.ImagePath
                });

                foreach (Article article in _articlesPanier)
                {
                    Console.WriteLine($"- Designation : {article.Designation}, Quantite : {article.Quantite}, Prix : {article.Prix}");
                }
                RaisePropertyChanged("TotalAPayer"); // Appel à RaisePropertyChanged pour notifier la vue de la modification de la propriété TotalAPayer
            }
        }

        // Méthode appelée lorsque l'utilisateur clique sur "Vider le panier"
        public void ViderPanier()
        {
            ArticlesPanier.Clear();
            TotalAPayer = 0;
            RaisePropertyChanged(nameof(TotalAPayer));
        }

        // Méthode appelée lorsque l'utilisateur clique sur "Confirmer le panier"
        public void ConfirmerPanier()
        {
            // Sauvegarder le vecteur d'articles et le total dans un fichier XML
            string fileName = "commande.xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Commande");

                // Écrire les articles dans le fichier XML
                writer.WriteStartElement("Articles");
                foreach (Article article in _articlesPanier)
                {
                    writer.WriteStartElement("Article");
                    writer.WriteElementString("Designation", article.Designation);
                    writer.WriteElementString("Quantite", article.Quantite.ToString());
                    writer.WriteElementString("Prix", article.Prix.ToString());
                    writer.WriteElementString("imagePath", "");
                    writer.WriteEndElement(); // Fermer l'élément "Article"
                }
                writer.WriteEndElement(); // Fermer l'élément "Articles"

                // Écrire le total dans le fichier XML
                writer.WriteElementString("Total", TotalAPayer.ToString());

                writer.WriteEndElement(); // Fermer l'élément "Commande"
                writer.WriteEndDocument();
            }

            Console.WriteLine("Les informations de commande ont été sauvegardées dans le fichier XML.");

            // Invoker l'événement ConfirmerPanierRequested
            ConfirmerPanierRequested?.Invoke(this, EventArgs.Empty);
        }


        // Méthode appelée lorsque l'utilisateur clique sur "Annuler" dans le fenetre confirmerWindow
        private void Annuler()
        {
            AnnulerConfirmerWindow?.Invoke(this, EventArgs.Empty);
        }



        private void OuvrirPoliceWindow()
        {

            OuvrirPoliceWindowRequested?.Invoke(this, EventArgs.Empty);
            
        }

        private void ValiderPoliceWindow()
        {
            ValiderPoliceWindowRequested?.Invoke(this, EventArgs.Empty);
        }

        public void EnregistrerCommande()
        {
            // 1. Créer un client sur la base des informations du formulaire de la vue
            _client = new Client
            {
                Nom = Nom,
                Prenom = Prenom,
                Adresse = Adresse,
                Age = Age,
                NumTel = GSM
            };

            // 2. Afficher le client en console
            Console.WriteLine("Nom: " + _client.Nom);
            Console.WriteLine("Prénom: " + _client.Prenom + "\n*************");

            // 3. Enregistrement du client
            Client.AddListeCli(_client);

            // 4. Lire le fichier "commande.xml" et mettre son contenu dans le vecteur d'articles
            string fileName = "commande.xml";

            if (File.Exists(fileName))
            {
                try
                {
                    XDocument doc = XDocument.Load(fileName);

                    _articlesPanier.Clear();

                    foreach (XElement element in doc.Descendants("Article"))
                    {
                        string designation = element.Element("Designation")?.Value;
                        int quantite = int.Parse(element.Element("Quantite")?.Value);
                        double prix = double.Parse(element.Element("Prix")?.Value);
                        string image = "";

                        Article article = new Article(designation, quantite, (float)prix, image);
                        _articlesPanier.Add(article);
                    }

                    Console.WriteLine("Les informations de commande ont été lues à partir du fichier XML.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Une erreur s'est produite lors de la lecture du fichier XML : " + ex.Message);
                }
            }

            // 5. Sauvegarder les informations de commande dans un fichier XML
            fileName = "Commande_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Commande");

                // Écrire les informations du client dans le fichier XML
                writer.WriteStartElement("Client");
                writer.WriteElementString("Nom", _client.Nom);
                writer.WriteElementString("Prenom", _client.Prenom);
                writer.WriteElementString("Adresse", _client.Adresse);
                writer.WriteEndElement(); // Fermer l'élément "Client"

                // Écrire les articles dans le fichier XML
                writer.WriteStartElement("Articles");
                foreach (Article article in _articlesPanier)
                {
                    writer.WriteStartElement("Article");
                    writer.WriteElementString("Designation", article.Designation);
                    writer.WriteElementString("Quantite", article.Quantite.ToString());
                    writer.WriteElementString("Prix", article.Prix.ToString());
                    writer.WriteElementString("ImagePath","");
                    writer.WriteEndElement(); // Fermer l'élément "Article"
                }
                writer.WriteEndElement(); // Fermer l'élément "Articles"

                writer.WriteEndElement(); // Fermer l'élément "Commande"
                writer.WriteEndDocument();
            }

            Console.WriteLine("Les informations du client et de commande ont été sauvegardées dans le fichier XML.");

            // Afficher les données en console
            Console.WriteLine("Client :");
            Console.WriteLine($"- Nom : {_client.Nom}");
            Console.WriteLine($"- Prénom : {_client.Prenom}");
            Console.WriteLine($"- Adresse : {_client.Adresse}");
            Console.WriteLine("Articles :");
            foreach (Article article in _articlesPanier)
            {
                Console.WriteLine($"- {article.Designation} (Quantité : {article.Quantite}, Prix : {article.Prix})");
            }

            // 6. Fermer la fenêtre
            AnnulerConfirmerWindow?.Invoke(this, EventArgs.Empty);
        }


    }
}
