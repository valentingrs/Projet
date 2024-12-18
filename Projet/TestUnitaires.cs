using System;
using static Projet.D�;

//Faire les test pour le vide et le null

namespace Projet
{
	internal class TestUnitaires
	{
		
		// Test de la m�thode RemplirDe -> voir si la proportion de chaque lettre est respect�e
		static public void TestRemplir(int n) // fonction � la con juste pour voir si �a marche
		{
			Console.WriteLine("Test de la m�thode RemplirDe : ");
			Dictionary<char, int> dict = new Dictionary<char, int>
            { {'A', 0},{'B', 0},{'C', 0},{'D', 0},{'E', 0},{'F', 0},{'G', 0}, {'H', 0},{'I', 0},{'J', 0},{'K', 0},{'L', 0},{'M', 0},{'N', 0},
			{'O', 0},{'P', 0},{'Q', 0},{'R', 0},{'S', 0},{'T', 0}, {'U', 0},{'V', 0}, {'W', 0},{'X', 0},{'Y', 0},{'Z', 0},};

			Dictionary<char, int> valeurLettres = new Dictionary<char, int>
			{ { 'A', 9 }, { 'B', 2 }, { 'C', 2 }, { 'D', 3 }, { 'E', 15 }, { 'F', 2 }, { 'G', 2 }, { 'H', 2 }, { 'I', 8 }, { 'J', 1 }, { 'K', 1 },
			{ 'L', 5 }, { 'M', 3 }, { 'N', 6 }, { 'O', 6 }, { 'P', 2 }, { 'Q', 1 }, { 'R', 6 }, { 'S', 6 }, { 'T', 6 }, { 'U', 6 }, { 'V', 2 }, 
			{ 'W', 1 }, { 'X', 1 }, { 'Y', 1 }, { 'Z', 1 } };

			string filename = "Lettres.txt";


			for (int i = 0; i < n; i++)
			{
				
				D� de = new D�();
				for (int j = 0; j < 6; j++)
				{
					switch (de.LettresDe[j])
					{
						case 'A': dict['A']++; break;
						case 'B': dict['B']++; break;
						case 'C': dict['C']++; break;
						case 'D': dict['D']++; break;
						case 'E': dict['E']++; break;
						case 'F': dict['F']++; break;
						case 'G': dict['G']++; break;
						case 'H': dict['H']++; break;
						case 'I': dict['I']++; break;
						case 'J': dict['J']++; break;
						case 'K': dict['K']++; break;
						case 'L': dict['L']++; break;
						case 'M': dict['M']++; break;
						case 'N': dict['N']++; break;
						case 'O': dict['O']++; break;
						case 'P': dict['P']++; break;
						case 'Q': dict['Q']++; break;
						case 'R': dict['R']++; break;
						case 'S': dict['S']++; break;
						case 'T': dict['T']++; break;
						case 'U': dict['U']++; break;
						case 'V': dict['V']++; break;
						case 'W': dict['W']++; break;
						case 'X': dict['X']++; break;
						case 'Y': dict['Y']++; break;
						case 'Z': dict['Z']++; break;
						default: break;
					}
				}
			}
			for (int i = 0; i < 26; i++)
			{
				char elem = dict.ElementAt(i).Key;
				double rapport = Convert.ToDouble(dict[elem]) / Convert.ToDouble(6 * n);
				double valeurTheorique = valeurLettres[elem] / Convert.ToDouble(100);
				Console.WriteLine("Ratio de " + elem + ": " + rapport + " | Valeur th�orique : " + valeurTheorique);
			}

		}

		static public void TestDe()
		{
			D� de = new D�();
			if (de.LettresDe.Length != 6) { Console.WriteLine("Echec du test, pas la bonne longueur"); }
			else if (de.FaceVisible < 0 || de.FaceVisible >=6) { Console.WriteLine("La face visible ne marche pas"); }
			else { Console.WriteLine("TestDe r�ussi, bonne longeuur, bonne face visible"); }
		}

		static public void TestDeString()
		{
			D� de = new D�();
			string[] tab = (de.ToString()).Split(',');
			if (Convert.ToChar(tab[0]) != de.LettresDe[de.FaceVisible]) { Console.Write("Echec du test, la face visible n'est pas en prmeier"); }
			else { Console.WriteLine("Test r�ussi"); }

		}

		static public void TestLance(int n)
		{
			D� de = new D�();
			Console.WriteLine(de);
			for (int i = 0; i < n; i++)
			{
				de.Lance();
				Console.WriteLine(de);
			}

		}

		static public void TestJoueur()
		{
			Joueur joueur = new Joueur("Pierre");
			Joueur joueur2 = new Joueur("Jules", 10);
			if (joueur.Nom != "Pierre" || joueur2.Nom != "Jules")
				Console.WriteLine("Echec, le nom est incorrect");
			else if (joueur.Score != 10 || joueur2.Score != 0)
				Console.WriteLine("Echec, le score est incorrect");
			else
				Console.WriteLine("Test r�ussi");
		}

		static public void TestAdd()
		{
			Joueur joueur = new Joueur("Pierre", 5);
			joueur.Add_Mot("chat");
			if (joueur.Score != 6) { Console.WriteLine("Echec du test, score incorrect :("); }
			else if (!joueur.MotsTrouves.Contains("chat")) { Console.WriteLine("Echec du test, mot non ajout�"); }
			else { Console.WriteLine("Test r�ussi !"); }
		}

		static public void TestContains()
		{
			Joueur joueur = new Joueur("Pierre");
			joueur.Add_Mot("chat");
			if (!joueur.Contain("chat"))
				Console.WriteLine("TestContainMotPresent �chou�: Mot trouv�, mais Contain a renvoy� false");
			else
				Console.WriteLine("TestContainMotPresent r�ussi");
			if (joueur.Contain("chien"))
				Console.WriteLine("TestContainMotPresent �chou�: Mot trouv�, mais Contain a renvoy� false");
			else
				Console.WriteLine("TestContainMotPresent r�ussi");
		}

        public static void TestDictionnaire()
        {
            string filename = "MotsPossiblesFR.txt";
            Dictionnaire dicoFr = new Dictionnaire("fr");
			for (int i =0; i < dicoFr.Mots.Count(); i++)
			{
				if (!dicoFr.Contains(dicoFr.Mots[i])) 
				{ 
					Console.WriteLine(dicoFr.Mots[i] + " echec du test");
					break;
				}

			}
			Console.WriteLine(dicoFr.Contains("VER"));
            
        }



        public static void TestPlateau()
        {
            D�[,] matrice_des = new D�[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    D� de = new D�();
                    matrice_des[i, j] = de;
                }
            }
            Plateau plateau = new Plateau(matrice_des, "fr");
            Console.WriteLine(plateau);

            Console.Write("Entrer un mot : ");
            string mot = Console.ReadLine();
            Console.WriteLine("Votre mot  :" + mot);
            Console.WriteLine(plateau.ContraintePlateau(mot));
        }

        public static void TestJeu()
        {
            Joueur joueur1 = new Joueur("joueur 1 ");
            Joueur joueur2 = new Joueur("joueur 2 ");
            Plateau plateau = null;
            DateTime heureDebut = DateTime.Now;
			int time = 300;
            Jeu jeu = new Jeu(joueur1, joueur2, plateau, heureDebut, time);

            jeu.InitialisationJeu();
        }


    }
}