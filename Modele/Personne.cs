using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Modele
{
    [Serializable]
    public class Personne
    {
        #region VARIABLES_MEMBRES
        private string _nom;
        private string _prenom;
        private string _adresse;
        private int _age;
        #endregion

        #region PROPRIETES
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value >= 0 ? value : 0; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Personne()
        {
            _nom = "default";
            _prenom = "default";
            _adresse = "default";
            _age = 0;
        }

        public Personne(string nom, string prenom, string adresse, int age)
        {
            _nom = nom;
            _prenom = prenom;
            _adresse = adresse;
            _age = age >= 0 ? age : 0;
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return _nom + " " + _prenom + " " + _adresse + " " + _age;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Personne autrePersonne = (Personne)obj;

            return _nom == autrePersonne.Nom &&
                   _prenom == autrePersonne.Prenom &&
                   _adresse == autrePersonne.Adresse &&
                   _age == autrePersonne.Age;
        }

        public void Save(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }

        public static Personne Load(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Personne>(jsonString);
        }
        #endregion
    }
}
