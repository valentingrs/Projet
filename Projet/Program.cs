using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Projet.TestUnitaires;
using static Projet.Dé;
using static Projet.Dictionnaire;
using static Projet.Joueur;
using static Projet.Jeu;
using static Projet.Plateau;

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

            Dé[,] matrice_des = new Dé[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dé de = new Dé();
                    matrice_des[i, j] = de;
                }
            }

            Plateau plateau = new Plateau(matrice_des);
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