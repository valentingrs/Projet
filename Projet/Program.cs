using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Projet.De;
using static Projet.TestUnitaires;
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
            string filename = "MotsPossiblesFR.txt";
            Dictionnaire dicoFr = new Dictionnaire(filename, "fr");
            Console.Write(dicoFr.toString());
        }

        

        public static void TestPlateau()
        {
            for (int i = 0; i < 5; i++)
            {
                Plateau plateau = new Plateau("Lettres.txt");
                plateau.toString();
                Console.WriteLine(" ");
            }

        }

        public static void TestJeu()
        {
            Joueur joueur1 = new Joueur("joueur 1 ");
            Joueur joueur2 = new Joueur("joueur 2 ");
            Plateau plateau = new Plateau("Lettres.txt");
            DateTime heureDebut = DateTime.Now;
            Jeu jeu = new Jeu(joueur1, joueur2, plateau, heureDebut);
            jeu.InitialisationJeu();


        }
        public static void Main(string[] args)
        {
            TestUnitaires.TestRemplir(10000);
        }


    }
}