using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Modele
{
    [Serializable]
    public class Article
    {
        #region VARIABLES_MEMBRES
        private string _designation;
        private int _quantite;
        private float _prix;
        private string _imagePath;
        #endregion

        #region PROPRIETES
        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        public int Quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }

        public float Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Article()
        {
            _designation = "Nike default";
            _quantite = 0;
            _prix = 0.0f;
            _imagePath = string.Empty;
        }

        public Article(string designation, int quantite, float prix, string imagePath)
        {
            _designation = designation;
            _quantite = quantite;
            _prix = prix;
            _imagePath = imagePath;
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return _designation + " " + _quantite + " " + _prix;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Article autreArticle = obj as Article;

            if (autreArticle == null)
                return false;

            return _designation == autreArticle.Designation && _quantite == autreArticle.Quantite && _prix == autreArticle.Prix;
        }

        public static void SaveXML(List<Article> articles, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Article>));

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, articles);
            }
        }

        public static List<Article> LoadXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Article>));

            using (StreamReader reader = new StreamReader(fileName))
            {
                return (List<Article>)serializer.Deserialize(reader);
            }
        }
        #endregion
    }
}
