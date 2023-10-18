using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace TestClasses
{
    public class TestClasses
    {
        public static void Main()
        {
            Console.WriteLine("------------------Test de la classe personne------------------");
            Console.WriteLine();
            Console.WriteLine();
            Personne personne1 = new Personne();

            // Affichage des informations de la personne1
            Console.WriteLine("Personne1 : " + personne1.ToString());

            // Création d'un objet Personne avec le constructeur prenant des paramètres
            Personne personne2 = new Personne("Reinders", "Sebastien", "rue de l'Eglise 159", 27);

            // Affichage des informations de la personne2
            Console.WriteLine("Personne2 : " + personne2.ToString());

            // Modification des propriétés de la personne1
            personne1.Nom = "Banushi";
            personne1.Prenom = "Arber";
            personne1.Adresse = "rue des Pommes 148";
            personne1.Age = 25;

            // Affichage des informations de la personne1 après modification
            Console.WriteLine("Personne1 modifiée : " + personne1.ToString());

            // Comparaison des deux objets Personne
            if (personne1.Equals(personne2))
            {
                Console.WriteLine("Les deux personnes sont identiques.");
            }
            else
            {
                Console.WriteLine("Les deux personnes sont différentes.");
            }
            Console.WriteLine();
            Console.WriteLine();





            Console.WriteLine("------------------Test de la classe Employe------------------");
            Console.WriteLine();
            Console.WriteLine();
            // Test de création d'un employé avec les valeurs par défaut
            Employe employe1 = new Employe();
            Console.WriteLine("Employe1 : " + employe1);

            // Test de création d'un employé avec des valeurs spécifiées
            Employe employe2 = new Employe("Reinders", "Sébastien", "rue de l'Eglise 159", 30, 1234, new DateTime(2021, 4, 1), 25.0f);
            Console.WriteLine("Employe2 : " + employe2);

            // Test de modification des propriétés d'un employé
            employe2.Nom = "Banushi";
            employe2.Prenom = "Arber";
            employe2.Adresse = "rue des Pommes 148";
            employe2.Age = 28;
            employe2.NumIntervenant = 5678;
            employe2.DateEntree = new DateTime(2021, 1, 1);
            employe2.SalaireHoraire = 30.0f;

            Console.WriteLine("Employe2 modifié : " + employe2);

            // Test d'égalité entre deux employés
            Employe employe3 = new Employe("Reinders", "Sébastien", "rue de l'Eglise 159", 30, 1234, new DateTime(2021, 4, 1), 25.0f);
            Console.WriteLine("Employe2 == Employe3 : " + (employe2 == employe3));
            Console.WriteLine("Employe2.Equals(Employe3) : " + employe2.Equals(employe3));
            

            // Test de création d'un employé avec des valeurs non valides
            Employe employe4 = new Employe("Pierre", "Cedric", "rue Fausse 404", -10, 1234, new DateTime(2021, 4, 1), -25.0f);
            Console.WriteLine("Employe4 : " + employe4);
            Console.WriteLine();
            Console.WriteLine();





            Console.WriteLine("------------------Test de la classe Client------------------");
            Console.WriteLine();
            Console.WriteLine();
            // Création d'un nouveau client
            Client client1 = new Client("Reinders", "Sébastien", "rue de l'Eglise 159", 35, 123, 10, "0496979823");

            // Affichage des informations du client
            Console.WriteLine(client1.ToString());

            // Modification des informations du client
            client1.Nom = "Martin";
            client1.Points = -5;
            client1.NumTel = "0485544445";

            // Affichage des nouvelles informations du client
            Console.WriteLine(client1.ToString());

            // Création d'un deuxième client
            Client client2 = new Client("Dupont", "Jacques", "rue des Martyrs 125", 35, 123, 10, "0485898678");

            // Vérification de l'égalité entre les deux clients
            Console.WriteLine(client1.Equals(client2)); // Doit afficher True

            // Création d'un troisième client différent
            Client client3 = new Client("Patriote", "Saul", "rue des Champs 148", 42, 456, 5, "0486362512");

            // Vérification de l'égalité entre le premier et le troisième client
            Console.WriteLine(client1.Equals(client3)); // Doit afficher False
            Console.WriteLine();
            Console.WriteLine();





            Console.WriteLine("------------------Test de la classe Article------------------");
            Console.WriteLine();
            Console.WriteLine();

            // Création d'une liste d'articles
            List<Article> articles = new List<Article>();

            // Ajout d'articles à la liste
            articles.Add(new Article("Air Max 90", 10, 150.0f, "Images/airmax90.png"));
            articles.Add(new Article("Air Jordan 1", 5, 200.0f, "Images/jordan.png"));
            articles.Add(new Article("Air force", 8, 100.0f, "Images/airforce.png"));

            // Affichage des informations des articles
            foreach (Article article in articles)
            {
                Console.WriteLine(article.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();
        }

    }

}