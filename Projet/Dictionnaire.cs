namespace Projet
{
    public class Dictionnaire
    {
        private readonly string[] mots;
        private string langue;

        public Dictionnaire(string filename, string langue)
        {
            this.langue = langue;
            List<string> listeMots = LireFichierMots(filename);
            this.mots = new string[listeMots.Count()];
            for (int i = 0; i < mots.Length; i++)
            {
                mots[i] = listeMots[i];
            }
            TriDico();
        }

        public List<string> LireFichierMots(string filename)
        {
            List<string> dico = new List<string>();
            string[] lignes = File.ReadAllLines(filename);
            foreach (string line in lignes)
            {
                string[] motsParLigne = line.Split(' ');
                foreach (string mot in motsParLigne)
                {
                    dico.Add(mot);
                }
            }
            return dico;

        }

        public string[] Mots
        {
            get { return mots; }
        }

        public int MotsLongueur(int longueur)
        {
            int occ = 0;
            foreach (string mot in mots)
            {
                if (mot.Length == longueur) { occ++; }
            }
            return occ;
        }

        public int MotsParLettre(char lettre)
        {

            int occ = 0;
            foreach (string mot in mots)
            {
                string l = lettre.ToString();
                l = l.ToUpper();
                lettre = Convert.ToChar(l);
                if (mot.Length != 0)
                {
                    if (mot[0] == lettre) { occ++; }
                }

            }
            return occ;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 2; i <= 24; i++)
            {
                int occ = MotsLongueur(i);
                if (occ != 0)
                {
                    s = s + i + " : " + occ + "; ";
                }
            }
            s = s + "\n";
            string alphabet = "AZERTYUIOPQSDFGHJKLMWXCVBN";
            foreach (char lettre in alphabet)
            {
                int occ = MotsParLettre(lettre);
                s = s + lettre + " : " + occ + " ; ";
            }
            return s;
        }

        public void LireMots()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(mots[i] + " ");
            }
            Console.WriteLine(langue);
        }

        public void TriDico() // le trier avec du tri fusion
        {
            for (int i = 0; i < mots.Length; i++)
            {
                int minIndex = 1;
                for (int j = i + 1; j < mots.Length; j++)
                {
                    if (String.Compare(mots[minIndex], mots[j]) < 0) { minIndex = j; }
                }
                if (minIndex != i)
                {
                    string temp = mots[i];
                    mots[i] = mots[minIndex];
                    mots[minIndex] = temp;
                }
            }
        }
        
        public int RechercheDicho(string mot, string[] tab, int deb, int fin)
        {
            Console.WriteLine(tab[deb] + "  " + tab[fin]);
            int mil = (deb + fin) / 2;
            if (deb > fin) { return -1; }
            else
            {
                if (mot == tab[mil]) { return mil; }
                else
                {
                    if (String.Compare(mot, tab[mil]) < 0)
                    {
                        return RechercheDicho(mot, tab, mil + 1, fin);
                    }
                    else
                    {
                        return RechercheDicho(mot, tab, deb, mil - 1);
                    }
                }
            }
        }
        public bool Contains(string mot)
        {
            // on suppose que le dictionnaire est dans l'ordre alphabétiqeu donc trié
            return (!(RechercheDicho(mot, mots, 0, mots.Length - 1) == -1));
        }


    }
}