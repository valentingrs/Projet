using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Projet.TestUnitaires;
using static Projet.Dé;
using static Projet.Dictionnaire;
using static Projet.Joueur;
using static Projet.Jeu;
using static Projet.Plateau;

// tous les trucs à améliorer
// trucs plus importants dans le code : 
// nuage de mots
// complexité des méthodes, simplification de code, regions, commentaires, ...
// posssibilité de faire à plusieurs joueurs ; de choisir le temps de la partie
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
        public static void Main(string[] args)
        {
            Console.Write("Le premier joueur rentre un pseudo : ");
            Joueur joueur1 = new Joueur(Console.ReadLine());
            Console.Write("Le deuxième joueur rentre un pseudo (pas le même si possible) : ");
            Joueur joueur2 = new Joueur(Console.ReadLine());

            Dé[,] matrice_des = new Dé[4, 4]; // création des des
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dé de = new Dé();
                    matrice_des[i, j] = de;
                }
            }

            Plateau plateau = new Plateau(matrice_des, "en");
            DateTime heureDebut = DateTime.Now;
            Jeu jeu = new Jeu(joueur1, joueur2, plateau, heureDebut);

            jeu.InitialisationJeu();
            jeu.PartieComplete();
            if (jeu.PartieTerminee == true)
            {
                jeu.FinPartie();
            }
        }


    }
}