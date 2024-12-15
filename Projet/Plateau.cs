using System.Diagnostics.CodeAnalysis;
using static Projet.De;
using static Projet.Dictionnaire;
using static Projet.Joueur;

namespace Projet
{
	public class Plateau
	{
		#region Attributs

		private D�[,] matrice_des = new D�[4,4];
		private char[,] valSup = new char[4,4];
		#endregion Attributs

		#region Constructeur

		public Plateau(string fileLettres)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					D� de = new D�(fileLettres);
					matrice_des[i, j] = de;
					valSup[i, j] = de.LettresDe[de.FaceVisible];
				}
			}
			
		}

		#endregion Constructeur

		#region Propri�t�
		
		#endregion Propri�t�

		#region M�thode

		public void toString()
		{
			for(int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					Console.Write(valSup[i, j] + " ");
				}
				Console.WriteLine(" ");
			}
		}

		public void TestPlateau(string mot)
		{
			//
			bool respect = true;
			Dictionnaire dicoFr = new Dictionnaire("MotsPossiblesFR.txt", "fr");
			
		}



		#endregion Methode
	}
}