namespace Projet
{
	internal class De
	{
		public class D�
		{
			private readonly char[] lettresDe;
			private int faceVisible;
			public D�(string fileLettres)
			{
				char[] lettresDe = new char[6];
				this.lettresDe = lettresDe;

				List<char> alphabet = LettresFichiers(fileLettres);
				RemplirDe(alphabet);

				Lance();
			}

			public char[] LettresDe
			{
				get { return lettresDe; }
			}

			public int FaceVisible
			{
				get { return faceVisible; }
				set { faceVisible = value; }
			}

			private List<char> LettresFichiers(string filename)
			{
				List<char> listeLettres = new List<char>();

				string[] lignes = File.ReadAllLines(filename);
				foreach (string ligne in lignes)
				{
					string[] tabLigne = ligne.Split(';');
					for (int i = 0; i < Convert.ToInt32(tabLigne[2]); i++)
					{
						listeLettres.Add(Convert.ToChar(tabLigne[0]));
					}
				}
				return listeLettres;
			}

			private bool RemplirDe(List<char> alphabet)
			{
				bool full = true;
				int n = alphabet.Count - 1;
				for (int i = 0; i < 6; i++)
				{
					Random r = new Random();
					int posLettreTiree = r.Next(0, n);
					lettresDe[i] = alphabet[posLettreTiree];
				}

				for (int i = 0; i < 6; i++)
				{
					if (lettresDe[i] == ' ') { full = false; }
				}
				return full;
			}

			public void Lance()
			{
				Random r = new Random();
				int i = r.Next(0, 5);
				this.faceVisible = i;
			}

			public override string ToString()
			{
				string de = "";

				for (int i = 0; i < 6; i++)
				{
					if (i == 4 && faceVisible == 5) { de = de + lettresDe[i]; }
					else if (i == this.faceVisible) { de = lettresDe[i] + "," + de; }
					else
					{
						if (i == 5) { de = de + lettresDe[i]; }
						else { de = de + lettresDe[i] + ','; }
					}
				}
				return de;
			}
		}

	}
}