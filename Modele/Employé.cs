using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Modele
{
    [Serializable]
    public class Employe : Intervenant
    {
        #region VARIABLES_MEMBRES
        private DateTime _dateEntree;
        private float _salaireHoraire;
        #endregion

        #region PROPRIETES
        public DateTime DateEntree
        {
            get { return _dateEntree; }
            set { _dateEntree = value; }
        }

        public float SalaireHoraire
        {
            get { return _salaireHoraire; }
            set { _salaireHoraire = value >= 0.0f ? value : 0.0f; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Employe() : base()
        {
            _dateEntree = DateTime.Now;
            _salaireHoraire = 0.0f;
        }

        public Employe(string nom, string prenom, string adresse, int age, int numIntervenant, DateTime dateEntree, float salaireHoraire) : base(nom, prenom, adresse, age, numIntervenant)
        {
            _dateEntree = dateEntree;
            _salaireHoraire = salaireHoraire >= 0.0f ? salaireHoraire : 0.0f;
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return base.ToString() + " " + _dateEntree.ToShortDateString() + " " + _salaireHoraire;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            Employe autreEmploye = obj as Employe;

            if (autreEmploye == null)
                return false;

            return _dateEntree == autreEmploye.DateEntree && _salaireHoraire == autreEmploye.SalaireHoraire;
        }
        #endregion
    }
}

