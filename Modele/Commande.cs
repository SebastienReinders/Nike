using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Modele
{
    [Serializable]
    public class Commande
    {
        private ObservableCollection<Article> _panier;
        private Client _coordonnees;

        public ObservableCollection<Article> Panier
        {
            get { return _panier; }
            set { _panier = value; }
        }

        public Client Coordonnees
        {
            get { return _coordonnees; }
            set { _coordonnees = value; }
        }

        public Commande()
        {
            _panier = new ObservableCollection<Article>();
            _coordonnees = null;
        }

        public Commande(ObservableCollection<Article> panier, Client coordonnees)
        {
            _panier = panier;
            _coordonnees = coordonnees;
        }

        public override string ToString()
        {
            return $"Commande de {Coordonnees?.Nom} {Coordonnees?.Prenom}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Commande autreCommande = obj as Commande;

            if (autreCommande == null)
                return false;

            return Panier == autreCommande.Panier && Coordonnees == autreCommande.Coordonnees;
        }

        public void SaveXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Commande));

            using (System.IO.TextWriter writer = new System.IO.StreamWriter(fileName))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static Commande LoadXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Commande));

            using (System.IO.TextReader reader = new System.IO.StreamReader(fileName))
            {
                return (Commande)serializer.Deserialize(reader);
            }
        }
    }
}
