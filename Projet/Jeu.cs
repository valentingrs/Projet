using static Projet.Dé;
using static Projet.Dictionnaire;
using static Projet.Joueur;
using static Projet.Plateau;
// améliorations : affichage chrono inutile des fois
// arrêter dès que le temps imparti est écoulé ? est ce que c'est utile d'afficher le temps restant ?
// posssibilité de faire à plusieurs joueurs
// convertir temps restant de la partie en affiahce minutes secondes
// possibilité de choisir le temps dans la partie

namespace Projet
{
	public class Jeu
	{
		private Joueur joueur1;
		private Joueur joueur2;
		private Plateau plateau;
		private DateTime heureDebut;
		private int tempsEcoulePartie;
		private bool partieTerminee;
		private Dictionary<char, int> lettresScore = new Dictionary<char, int>();

		public Jeu(Joueur joueur1, Joueur joueur2, Plateau plateau, DateTime heureDebut)
		{
			this.joueur1 = joueur1;
			this.joueur2 = joueur2;
			this.plateau = plateau;
			this.heureDebut = heureDebut;
            this.tempsEcoulePartie = 0;
			this.partieTerminee = false;
			this.lettresScore = LettresScore();
		}

        public bool PartieTerminee
        {
            get { return partieTerminee; }
        }

        public void InitialisationJeu()
		{
			Console.WriteLine("La partie commence : ");
		}

		public void TourJoueur(Joueur joueur)
		{
			Console.WriteLine("Au tour de " + joueur.Nom);
			plateau.RelancerDes(); // bah du coup la première version du plateau sert à rien mais oklm
			Console.WriteLine(plateau);

			DateTime debutTour = DateTime.Now; // debut du tour
			Console.WriteLine();
			int tempsEcoule = Convert.ToInt32((DateTime.Now - debutTour).TotalSeconds); // temps ecoulé depuis le début du tour

            while (tempsEcoule < 60) // tant que il ne s'est pas écoulé 1 minute depuis le début du tour
			{
				Console.WriteLine("Temps restant du tour : " + (60-tempsEcoule) + "s");
				Console.Write("Rentrer un mot : ");

				string motRentre = Console.ReadLine();
				if (motRentre == "") { break; } // le joueur a plus d'inspi
				if (plateau.ContraintePlateau(motRentre.ToUpper()) == true)
				{
					joueur.MotsTrouves.Add(motRentre);
                    joueur.Score += CalculScore(motRentre);
				}

                tempsEcoule = Convert.ToInt32((DateTime.Now - debutTour).TotalSeconds);// maj temps écoulé
            }
			Console.WriteLine("Fin de votre tour " + joueur.Nom);
			joueur.AfficherMotsTrouves();
			joueur.AfficherScore();
        }

		private int CalculScore(string mot)
		{
			int score = 0;
			foreach (char l in mot)
			{
				score += lettresScore[l];
			}
			return score;
		}
        private Dictionary<char, int> LettresScore()
		{
			Dictionary<char, int> scoreLettres = new Dictionary<char, int>();
            string[] lignes = File.ReadAllLines("Lettres.txt");
			foreach (string ligne in lignes)
			{
				string[] tabLigne = ligne.Split(';');
				scoreLettres[Convert.ToChar(tabLigne[0])] = Convert.ToInt32(tabLigne[2]);
			}
			return scoreLettres;
        }

		public void PartieComplete()
		{
			int tempsEcoule = Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds);
			while (Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds) < 120)
			{
				Console.WriteLine(" ");
				TourJoueur(joueur1);
				Console.WriteLine(" ");

                tempsEcoule = Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds);
                Console.WriteLine("Temps restant de la partie : " + (360 - tempsEcoule) + " s \n");
                

                TourJoueur(joueur2);
				Console.WriteLine("\nFin du tour. \n");
				Console.WriteLine(joueur1.Nom + "  " + joueur1.Score + " - " + joueur2.Score + "  " + joueur2.Nom);

                tempsEcoule = Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds);

				if (tempsEcoule < 120) { Console.WriteLine("Temps restant de la partie : " + (360 - tempsEcoule) + " s \n"); }
                
			}
			partieTerminee = true;
		}

		public void FinPartie()
		{
			Console.WriteLine("Le temps impartie est écoulé, la partie est donc terminée.");
			Console.WriteLine(joueur1);
			Console.WriteLine(joueur2);
			if (joueur1.Score > joueur2.Score) { Console.WriteLine(joueur1.Nom + " a gagné."); }
			else if (joueur1.Score < joueur2.Score) { Console.WriteLine(joueur2.Nom + " a gagné"); }
			else { Console.WriteLine("Egalité !"); }
		}

	}
}