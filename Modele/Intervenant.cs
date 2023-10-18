using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Modele
{
    [Serializable]
    public class Intervenant : Personne
    {
        #region VARIABLES_MEMBRES
        private int _numIntervenant;
        #endregion

        #region PROPRIETES
        public int NumIntervenant
        {
            get { return _numIntervenant; }
            set { _numIntervenant = value >= 0 ? value : 0; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Intervenant() : base()
        {
            _numIntervenant = 0;
        }

        public Intervenant(string nom, string prenom, string adresse, int age, int numIntervenant) : base(nom, prenom, adresse, age)
        {
            _numIntervenant = numIntervenant >= 0 ? numIntervenant : 0;
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return base.ToString() + " " + _numIntervenant;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Intervenant autreIntervenant = (Intervenant)obj;

            return base.Equals(obj) && _numIntervenant == autreIntervenant.NumIntervenant;
        }

        public new void Save(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }

        public new static Intervenant Load(string fileName)
        {
            Intervenant? intervenant = Personne.Load(fileName) as Intervenant;

            if (intervenant != null)
            {
                string jsonString = File.ReadAllText(fileName);
                var jsonObject = JsonSerializer.Deserialize<JsonElement>(jsonString);

                if (jsonObject.TryGetProperty("numIntervenant", out JsonElement numIntervenantElement))
                {
                    intervenant.NumIntervenant = numIntervenantElement.GetInt32();
                }
            }

            return intervenant;
        }
        #endregion
    }
}
