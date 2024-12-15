using static Projet.De;
using static Projet.Dictionnaire;
using static Projet.Joueur;
using static Projet.Plateau;


namespace Projet
{
	public class Jeu
	{
		private Joueur joueur1;
		private Joueur joueur2;
		private Plateau plateau;
		private DateTime heureDebut;
		bool partieTerminee;

		public Jeu(Joueur joueur1, Joueur joueur2, Plateau plateau, DateTime heureDebut)
		{
			this.joueur1 = joueur1;
			this.joueur2 = joueur2;
			this.plateau = plateau;
			this.heureDebut = heureDebut;
			this.partieTerminee = false;
		}

		public void InitialisationJeu()
		{
			Console.WriteLine(joueur1.Nom);
			Console.WriteLine(joueur2.Nom + "\n");
			Console.WriteLine("La partie commence : ");
		}

		public void TourJoueur(Joueur joueur)
		{
			DateTime debutTour = DateTime.Now;
			while (Convert.ToInt32((DateTime.Now - debutTour).TotalSeconds) < 60) // tant que il ne s'est pas écoulé 1 minute depuis le début du tour
			{
				Console.Write("Rentrer un mot : ");
				string motRentre = Console.ReadLine();
				//if (plateau.TestPlateau(motRentre) == true)
				//{
				//    joueur.Score += CalculScore(motRentre);
				//}   
			}
			Console.WriteLine("Fin de votre tour " + joueur.Nom);
		}

		public void PartieComplete()
		{
			while (Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds) < 360)
			{
				plateau.toString();
				Console.WriteLine(" ");
				TourJoueur(joueur1);
				Console.WriteLine(" ");
				TourJoueur(joueur2);
				Console.WriteLine(" ");
				Console.WriteLine("Fin du tour.");
				Console.WriteLine(joueur1.toString());
				Console.WriteLine(joueur2.toString());
				Console.WriteLine(" ");
			}
			partieTerminee = true;
		}

		public void FinPartie()
		{
			Console.WriteLine("Le temps impartie est écoulé, la partie est donc terminée.");
			Console.WriteLine(joueur1.toString());
			Console.WriteLine(joueur2.toString());
			if (joueur1.Score > joueur2.Score) { Console.WriteLine(joueur1.Nom + " a gagné."); }
			else if (joueur1.Score < joueur2.Score) { Console.WriteLine(joueur2.Nom + " a gagné"); }
			else { Console.WriteLine("Egalité !"); }
		}

	}
}