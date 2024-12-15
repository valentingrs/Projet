using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Projet.De;
using static Projet.Dictionnaire;
using static Projet.Joueur;
using static Projet.Jeu;
using static Projet.Plateau;

namespace Projet
{
    internal class Program
    {

        static public void Test(int n) // fonction à la con juste pour voir si ça marche
        {
            int nbA = 0;
            int nbE = 0;
            int nbJ = 0;
            int nbZ = 0;
            for (int i = 0; i < n; i++)
            {
                string filename = "Lettres.txt";
                Dé de = new Dé(filename);
                for (int j = 0; j < 6; j++)
                {
                    if (de.LettresDe[j] == 'A') { nbA++; }
                    if (de.LettresDe[j] == 'E') { nbE++; }
                    if (de.LettresDe[j] == 'J') { nbJ++; }
                    if (de.LettresDe[j] == 'Z') { nbZ++; }
                }
            }
            Console.WriteLine("Nombre de A : " + nbA);
            Console.WriteLine("Ratio de A : " + Convert.ToDouble(nbA) / Convert.ToDouble(6 * n) + " ; 0.09 théorique");
            Console.WriteLine("\nNombre de E : " + nbE);
            Console.WriteLine("Ratio de E : " + Convert.ToDouble(nbE) / Convert.ToDouble(6 * n) + " ; 0.15 théorique");
            Console.WriteLine("\nNombre de Z : " + nbJ);
            Console.WriteLine("Ratio de Z : " + Convert.ToDouble(nbJ) / Convert.ToDouble(6 * n) + " ; 0.01 théorique");
            Console.WriteLine("\nNombre de J : " + nbZ);
            Console.WriteLine("Ratio de J: " + Convert.ToDouble(nbZ) / Convert.ToDouble(6 * n) + " ; 0.01 théorique");

        }

        public static void TestDe()
        {
            string filename = "Lettres.txt";
            Dé unDe = new Dé(filename);
            Console.WriteLine(unDe.toString());
            unDe.Lance();
            Console.WriteLine(unDe.toString());
        }



        public static void TestDictionnaire()
        {
            string filename = "MotsPossiblesFR.txt";
            Dictionnaire dicoFr = new Dictionnaire(filename, "fr");
            Console.Write(dicoFr.toString());
        }

        public static void TestJoueur()
        {
            Joueur j = new Joueur("valentin");
            foreach (string mot in j.MotsTrouves)
            {
                Console.Write(mot + " ");
            }
            Console.WriteLine(" ");
            j.Add_Mot("beau");
            foreach (string mot in j.MotsTrouves)
            {
                Console.Write(mot + " ");
            }
            Console.WriteLine(" ");
            j.Add_Mot("gosse");
            foreach (string mot in j.MotsTrouves)
            {
                Console.Write(mot + " ");
            }
            Console.WriteLine("\n" + j.Contain("beau") + " " + j.Contain("moche") + "\n");
            j.toString();

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
            TestJeu();
        }


    }
}