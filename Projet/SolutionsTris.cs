using System.Diagnostics;

namespace Projet
{
	public class SolutionsTris
	{
		public static void TestTris()
		{
			// Génération d'une liste de strings dans le pire cas (ordre décroissant)
			List<string> worstCase = GenerateWorstCase(10000); // Taille ajustable

			// Mesure du temps pour TriFusion
			var stopwatch = Stopwatch.StartNew();
			TriFusion(worstCase);
			stopwatch.Stop();
			Console.WriteLine($"TriFusion - Temps écoulé: {stopwatch.ElapsedMilliseconds} ms");

			// Régénérer le pire cas
			worstCase = GenerateWorstCase(10000);

			// Mesure du temps pour TriSelection
			stopwatch.Restart();
			TriSelection(worstCase);
			stopwatch.Stop();
			Console.WriteLine($"TriSelection - Temps écoulé: {stopwatch.ElapsedMilliseconds} ms");
		}

		static List<string> GenerateWorstCase(int size)
		{
			var list = new List<string>(size);
			for (int i = size; i > 0; i--)
			{
				list.Add(i.ToString());
			}
			return list;
		}
		// solutions retenue
		public static void TriFusion(List<string> liste)
		{
			if (liste.Count() <= 1)
			{
				return;
			}

			else
			{
				int mil = liste.Count() / 2;

				List<string> left = liste.GetRange(0, mil);
				List<string> right = liste.GetRange(mil, liste.Count() - mil);


				TriFusion(left);
				TriFusion(right);

				Fusion(liste, left, right);
			}

		}
		public static void Fusion(List<string> liste, List<string> left, List<string> right)
		{
			int i = 0;
			int j = 0;
			int k = 0;
			while (i < left.Count() && j < right.Count())
			{
				if (String.Compare(left[i], right[j]) <= 0)
				{
					liste[k] = left[i];
					i++;
				}
				else
				{
					liste[k] = right[j];
					j++;
				}
				k++;
			}

			while (i < left.Count())
			{
				liste[k] = left[i];
				i++;
				k++;
			}

			while (j < right.Count())
			{
				liste[k] = right[j];
				j++;
				k++;
			}
		}

		// tri selection, abandonné
		public static void TriSelection(List<string> liste)
		{

			for (int i = 0; i < liste.Count() - 1; i++)
			{
				int minIndex = i;
				for (int j = i + 1; j < liste.Count(); j++)
				{
					if (String.Compare(liste[j], liste[minIndex]) < 0)
					{
						minIndex = j;
					}
				}
				if (minIndex != i)
				{
					string temp = liste[i];
					liste[i] = liste[minIndex];
					liste[minIndex] = temp;
				}
			}
		}
	}
}