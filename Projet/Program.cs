using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Projet.TestUnitaires;
using static Projet.Dé;
using static Projet.Dictionnaire;
using static Projet.Joueur;
using static Projet.Jeu;
using static Projet.Plateau;
using static Projet.SolutionsTris;
using static System.Net.Mime.MediaTypeNames;


namespace Projet
{
    internal class Program
    {
        public static void ExecutionJeu()
        {
            Console.Write("Combien de temps pour la partie (en secondes) : ");
            int time = Convert.ToInt32(Console.ReadLine());
            Console.Write("En quelle langue voulez vous jouer en français (fr) ou anglais (en) : ");
            string langue;
            if (Console.ReadLine().ToLower() == "fr") {  langue = "fr"; }
            else if (Console.ReadLine().ToLower() == "en") { langue = "en"; }
            else
            {
                Console.WriteLine("Vous n'avez pas rentré une langue valide. Dans ce cas je chosis à votre place et on prend français");
                langue = "fr";
            }
            Console.Write("Le premier joueur rentre un pseudo : ");
            Joueur joueur1 = new Joueur(Console.ReadLine());
            Console.Write("Le deuxième joueur rentre un pseudo : ");            
            Joueur joueur2 = new Joueur(Console.ReadLine());

            Console.Write("Entrer la taille du plateau (nombre de dés par lignes et colonne) : ");
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

            Plateau plateau = new Plateau(matrice_des, langue);
            DateTime heureDebut = DateTime.Now;
            Jeu jeu = new Jeu(joueur1, joueur2, plateau, heureDebut, time);

            jeu.InitialisationJeu();
            jeu.PartieComplete();
            if (jeu.PartieTerminee) { jeu.FinPartie(); }
            

            NuageDeMots nuage = new NuageDeMots();
            nuage.Genere(joueur1.motsTrouves);
            nuage.Genere(joueur2.motsTrouves);
        }
        public static void Main(string[] args)
        {

            SolutionsTris.TestTris();
            
        }


    }
}