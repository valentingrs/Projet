using static Projet.D�;
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
		private DateTime heureDebut; // heure de d�but de la partie
		private int tempsPartie; // temps total de la partie
		private bool partieTerminee; // statut de la partie : en cours ou non
		private Dictionary<char, int> lettresScore = new Dictionary<char, int>(); // dictionnaire qui associe un score aux lettres

		public Jeu(Joueur joueur1, Joueur joueur2, Plateau plateau, DateTime heureDebut, int tempsPartie)
		{
			this.joueur1 = joueur1;
			this.joueur2 = joueur2;
			this.plateau = plateau;
			this.heureDebut = heureDebut;
			this.partieTerminee = false;
			this.lettresScore = LettresScore();
			this.tempsPartie = tempsPartie;
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
            Console.WriteLine(plateau);

            DateTime debutTour = DateTime.Now; // debut du tour
			Console.WriteLine();
			int tempsEcoule = Convert.ToInt32((DateTime.Now - debutTour).TotalSeconds); // temps ecoul� depuis le d�but du tour

            while (tempsEcoule < 60) // tant que il ne s'est pas �coul� 1 minute depuis le d�but du tour
			{

				Console.WriteLine("Temps restant du tour : " + (60-tempsEcoule) + "s");
				Console.Write("Rentrer un mot : ");

				string motRentre = Console.ReadLine().ToUpper();
				if (motRentre == "") { break; } // le joueur a plus d'inspi
				if (plateau.ContraintePlateau(motRentre) == true)
				{
					joueur.MotsTrouves.Add(motRentre);
                    joueur.Score += CalculScore(motRentre);
				}

                tempsEcoule = Convert.ToInt32((DateTime.Now - debutTour).TotalSeconds);// maj temps �coul�
            }
			Console.WriteLine("Fin de votre tour " + joueur.Nom);
			joueur.AfficherMotsTrouves();
			joueur.AfficherScore();

            
            plateau.RelancerDes(); // bah du coup la premi�re version du plateau sert � rien mais oklm
            
        }

		public int CalculScore(string mot)
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
			while (Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds) < tempsPartie)
			{
				Console.WriteLine(" ");
				TourJoueur(joueur1);
				Console.WriteLine(" ");
				
                tempsEcoule = Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds);
                Console.WriteLine("Temps restant de la partie : " + (tempsPartie - tempsEcoule) + " s \n");
                

                TourJoueur(joueur2);
				Console.WriteLine("\nFin du tour. \n");
				Console.WriteLine(joueur1.Nom + "  " + joueur1.Score + " - " + joueur2.Score + "  " + joueur2.Nom);

                tempsEcoule = Convert.ToInt32((DateTime.Now - heureDebut).TotalSeconds);

				if (tempsEcoule < tempsPartie) { Console.WriteLine("Temps restant de la partie : " + (tempsPartie - tempsEcoule) + " s \n"); }
                
			}
			partieTerminee = true;
		}

		public void FinPartie()
		{
			Console.WriteLine("Le temps impartie est �coul�, la partie est donc termin�e.");
			Console.WriteLine(joueur1);
			Console.WriteLine(joueur2);
			if (joueur1.Score > joueur2.Score) { Console.WriteLine(joueur1.Nom + " a gagn�."); }
			else if (joueur1.Score < joueur2.Score) { Console.WriteLine(joueur2.Nom + " a gagn�"); }
			else { Console.WriteLine("Egalit� !"); }
		}

	}
}