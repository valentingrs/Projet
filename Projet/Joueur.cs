using static System.Formats.Asn1.AsnWriter;

namespace Projet
{
	public class Joueur
	{
		#region Attributs

		/// Attributs de la classe joueur

		private string nom; /// nom du joueur
		private int score; /// score du joueur
		public List<string> motsTrouves; /// mots trouv�s par les joueurs

		#endregion Attributs

		#region Constructeurs

		/// Constructeurs de la classe joueur
		public Joueur(string nom, int score = 0)
		{
			/// Verifie si nom n'est pas nul ou juste compos� d'espaces et renvoie une exception
			if (nom == null || nom.Trim().Length == 0)
			{
				throw new ArgumentException("Le nom du joueur n'est pas adapt�e");
			}

			this.nom = nom; /// Nom du joueur
			this.score = score; /// Score obtenu par le joueur
			this.motsTrouves = new List<string>(); /// Mots Trouv�s par le joueur
		}

		#endregion Constructeurs

		#region Propri�t�s

		public string Nom
		{
			get { return nom; }
		}

		public int Score
		{
			get { return score; }
			set { score = value; }
		}

		public List<string> MotsTrouves
		{
			get { return motsTrouves; }
			set { motsTrouves = value; }
		}

		#endregion Propri�t�s

		#region M�thodes

		/// M�thode qui v�rifie si un mot a deja etais trouv� par le joueur par le pass�
		public bool Contain(string mot)
		{
			foreach (string Mot in motsTrouves) /// Traverse la liste
			{
				if (Mot == mot)
				{
					return true;
				}
			}
			return false;
		}

		public void Add_Mot(string mot)
		{
			if (nom == null || nom.Trim().Length == 0)
			{
				throw new ArgumentException("Le nom du joueur n'est pas adapt�e");
			}
			if (!Contain(mot))
			{
				motsTrouves.Add(mot);
			}
			Score += 1;
		}

		public void AfficherScore()
		{
			Console.WriteLine("Le score de " + nom + " est de " + score);
		}

		public void AfficherMotsTrouves()
		{
			Console.Write("Mots trouv�s : ");
			foreach (string mot in motsTrouves)
			{
				Console.Write(mot + " ");
			}
			Console.WriteLine();
		}

		public override string ToString()
		{
			return "Le joueur " + nom + " a le score de " + score + " points";
		}

		#endregion M�thodes
	}
}