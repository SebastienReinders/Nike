using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Modele
{
    [Serializable]
    public class Client : Intervenant
    {
        private int _points;
        private string _numTel;

        public int Points
        {
            get { return _points; }
            set { _points = value >= 0 ? value : 0; }
        }

        public string NumTel
        {
            get { return _numTel; }
            set { _numTel = value; }
        }

        public Client() : base()
        {
            _points = 0;
            _numTel = "";
        }

        public Client(string nom, string prenom, string adresse, int age, int numIntervenant, int points, string numTel) : base(nom, prenom, adresse, age, numIntervenant)
        {
            _points = points >= 0 ? points : 0;
            _numTel = numTel;
        }

        public override string ToString()
        {
            return base.ToString() + " " + _points + " " + _numTel;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            Client autreClient = obj as Client;

            if (autreClient == null)
                return false;

            return _points == autreClient.Points && _numTel == autreClient.NumTel;
        }

        public new void Save(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }

        public new static Client Load(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Client>(jsonString);
        }

        public static void SaveListeCli(List<Client> clients)
        {
            string fileName = "MesClients.txt";
            string jsonString = JsonSerializer.Serialize(clients);
            File.WriteAllText(fileName, jsonString);
        }

        public static void AddListeCli(Client client)
        {
            string fileName = "MesClients.txt";
            List<Client> clients = LoadListeCli();

            if (clients == null)
            {
                clients = new List<Client>();
            }

            clients.Add(client);

            SaveListeCli(clients);
        }

        public static List<Client> LoadListeCli()
        {
            string fileName = "MesClients.txt";

            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                List<Client> clients = JsonSerializer.Deserialize<List<Client>>(jsonString);
                return clients;
            }

            return null;
        }

        public void SaveXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Client));

            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}
