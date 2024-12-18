using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Projet.TestUnitaires;
using static Projet.Dé;
using static Projet.Dictionnaire;
using static Projet.Joueur;
using static Projet.Jeu;
using static Projet.Plateau;
using static System.Net.Mime.MediaTypeNames;

// tous les trucs à améliorer
// trucs plus importants dans le code : 
// nuage de mots
// complexité des méthodes, simplification de code, regions, commentaires, ...
// convertir temps restant de la partie en affiahce minutes secondes
// classe Jeu : arrêter dès que le temps imparti est écoulé ? est ce que c'est utile d'afficher le temps restant ?

// trucs par rapport au rendu final
// uml 
// rapport fnal avec tentatives pour la recherche d'un mot
// tests unitaires
// interface graphique ? ia ?


namespace Projet
{
    internal class Program
    {
        public static void ExecutionJeu()
        {
            Console.Write("Combien de temps pour la partie (en secondes) : ");
            int time = Convert.ToInt32(Console.ReadLine());
            Console.Write("Le premier joueur rentre un pseudo : ");
            Joueur joueur1 = new Joueur(Console.ReadLine());
            Console.Write("Le deuxième joueur rentre un pseudo : ");            
            Joueur joueur2 = new Joueur(Console.ReadLine());

            Console.Write("entrer la taille du plateau (nombre de dés par lignes et colonne: ");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n == null || n <= 1) 
            { 
                Console.Write("Entrer une taille valide : ");
                n = Convert.ToInt32(Console.ReadLine());
            }

            Dé[,] matrice_des = new Dé[n, n]; // création des des
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Dé de = new Dé();
                    matrice_des[i, j] = de;
                }
            }

            Plateau plateau = new Plateau(matrice_des, "en");
            DateTime heureDebut = DateTime.Now;
            Jeu jeu = new Jeu(joueur1, joueur2, plateau, heureDebut, time);

            jeu.InitialisationJeu();
            jeu.PartieComplete();
            jeu.FinPartie();

            //NuageDeMots nuage = new NuageDeMots();
            //nuage.Genere(joueur1.motsTrouves);
        }
        public static void Main(string[] args)
        {

            ExecutionJeu();
            
        }


    }
}