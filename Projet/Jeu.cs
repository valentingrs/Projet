using System.Runtime.CompilerServices;
using static Projet.Dé;
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
		private DateTime debutPartie; // heure de début de la partie
		private int tempsPartie; // temps que doit durer la partie
		private int tempsEcoulePartie; // temps ecoule depuis le début de la partie
		private bool partieTerminee; // statut de la partie : en cours ou non
		private Dictionary<char, int> lettresScore = new Dictionary<char, int>(); // dictionnaire qui associe un score aux lettres

		public Jeu(Joueur joueur1, Joueur joueur2, Plateau plateau, DateTime debutPartie, int tempsPartie)
		{
			this.joueur1 = joueur1;
			this.joueur2 = joueur2;
			this.plateau = plateau;
			this.debutPartie = debutPartie;
			this.partieTerminee = false;
			this.tempsEcoulePartie = 0; // au début 0s
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

            DateTime debutTour = DateTime.Now; /// debut du tour
			Console.WriteLine();

			int tempsEcoule = 0; /// temps ecoulé depuis le début du tour
			int tempsTour = 60; /// temps par défaut d'un tour

			if (tempsPartie - tempsEcoulePartie < 60) { tempsTour = tempsPartie - tempsEcoulePartie; } /// si un nouveau tour commence alors qu'il reste moins d'une minute
			bool continuerTour = true;

            while (tempsEcoule < tempsTour && continuerTour) /// tant que il ne s'est pas écoulé 1 minute depuis le début du tour
			{

				Console.WriteLine("Temps restant du tour : " + (tempsTour-tempsEcoule) + "s");
				Console.Write("Rentrer un mot : ");
				string motRentre = Console.ReadLine().Trim().ToUpper();
				if (motRentre == "") /// le joueur a plus d'inspi
                { 
					continuerTour = false; 
				} 
				if (plateau.ContraintePlateau(motRentre) == true)
				{
					joueur.MotsTrouves.Add(motRentre);
                    joueur.Score += CalculScore(motRentre);
				}

                tempsEcoule = Convert.ToInt32((DateTime.Now - debutTour).TotalSeconds);/// maj du temps écoulé depuis le début du tour
				tempsEcoulePartie = Convert.ToInt32((DateTime.Now - debutPartie).TotalSeconds); /// maj du temps écoulé depuis le début de la partie
                Console.WriteLine("");

            }
            Console.WriteLine("Fin de votre tour " + joueur.Nom);
			joueur.AfficherMotsTrouves();
			joueur.AfficherScore();

            
            plateau.RelancerDes();
            
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
			while (tempsEcoulePartie < tempsPartie)
			{
                Console.WriteLine("Temps restant de la partie : " + (tempsPartie - tempsEcoulePartie) + " s \n");
				TourJoueur(joueur1);
				Console.WriteLine(" ");

                Console.WriteLine("Temps restant de la partie : " + (tempsPartie - tempsEcoulePartie) + " s \n");
                

                TourJoueur(joueur2);
				Console.WriteLine("\nFin du tour. \n");
				Console.WriteLine(joueur1.Nom + "  " + joueur1.Score + " - " + joueur2.Score + "  " + joueur2.Nom);
                
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