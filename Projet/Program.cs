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
        public static void TestDictionnaire()
        {
            Dictionnaire dicoFr = new Dictionnaire("fr");
            string mot = dicoFr.Mots[50];
            Console.WriteLine(mot);
            Console.WriteLine(dicoFr.RechercheDichoRecursif(mot));
            Console.WriteLine(dicoFr.RechercheDichoRecursif("DLSKJDSMLQK"));
        }

        

        public static void TestPlateau()
        {
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
            Console.WriteLine(plateau);

            Console.Write("Entrer un mot : ");
            string mot = Console.ReadLine();
            Console.WriteLine("Votre mot  :" + mot);
            Console.WriteLine(plateau.ContraintePlateau(mot));
        }

        public static void TestJeu()
        {
            Dé[,] matrice_des = new Dé[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dé de = new Dé();
                    matrice_des[i, j] = de;
                }
            }
            Joueur joueur1 = new Joueur("joueur 1 ");
            Joueur joueur2 = new Joueur("joueur 2 ");
            Plateau plateau = new Plateau(matrice_des);
            DateTime heureDebut = DateTime.Now;
            Jeu jeu = new Jeu(joueur1, joueur2, plateau, heureDebut);
            jeu.InitialisationJeu();
            jeu.PartieComplete();
            if (jeu.PartieTerminee==true)
            {
                jeu.FinPartie();
            }

        }
        public static void Main(string[] args)
        {
            TestJeu();
        }


    }
}