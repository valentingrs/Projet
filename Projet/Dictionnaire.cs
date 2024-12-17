namespace Projet
{
    public class Dictionnaire
    {

        #region Attributs
        //private readonly string[] mots;
        private readonly List<string> mots;
        private Dictionary<int, List<string>> motsParLongueur;
        private Dictionary<char, List<string>> motsParLettres;
        private string langue;
        #endregion Attributs

        public Dictionnaire(string langue)
        {
            this.langue = langue;
            this.mots = LireFichierMots($"MotsPossibles{langue.ToUpper()}.txt");
            this.motsParLongueur = TriMotsParLongueur();
            this.motsParLettres = TriMotsParLettre();
        }

        #region Proprietes
        public string Langue
        {
            get { return langue; }
            set { langue = value; }
        }

        public List<string> Mots
        {
            get { return mots; }
        }
        #endregion Proprietes


        #region Methodes
        public List<string> LireFichierMots(string filename)
        {
            List<string> dico = new List<string>();
            string[] lignes = File.ReadAllLines(filename);
            foreach (string line in lignes)
            {
                string[] motsParLigne = line.Trim().Split(' ');
                foreach (string mot in motsParLigne)
                {
                    dico.Add(mot);
                }
            }
            return dico;
        }

        public Dictionary<int, List<string>> TriMotsParLongueur()
        {
            Dictionary<int, List<string>> motsParLongueur = new Dictionary<int, List<string>>();

            foreach (string mot in this.mots)
            {
                int longueur = mot.Length;

                if(!motsParLongueur.ContainsKey(longueur)) // si dans le dico il n'y a pas cette longueur la
                {
                    motsParLongueur[longueur] = new List<string>(); // alors on créé une nouvelle liste associée à une nv longuer
                }

                motsParLongueur[longueur].Add(mot); // on ajoute le mots à la liste de mots 
            }

            // tri de chaque liste
            foreach (int i in  motsParLongueur.Keys)
            {
                motsParLongueur[i].Sort();
            }

            return motsParLongueur;
        }

        public Dictionary<char, List<string>> TriMotsParLettre()
        {
            Dictionary<char, List<string>> motsParLettre = new Dictionary<char, List<string>>();
            
            foreach (string mot in this.mots)
            {
                char c = mot[0]; // premier caractère du mot

                if (!motsParLettre.ContainsKey(c)) // si dans le dico il n'y a pas de mot commencant par cette lettre
                { 
                    motsParLettre[c] = new List<string>(); // alors on créé une nouvelle liste associée à une nv longuer
                }
                motsParLettre[c].Add(mot); // on ajoute le mots à la liste de mots 
            }
            


            // tri de chaque liste
            foreach (char c in motsParLettre.Keys)
            {
                motsParLettre[c].Sort();
            }

            return motsParLettre;
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

        public string toString()
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


        public bool RechercheDichoRecursif(string mot, int deb = 0, int fin = -1)
        {
            if (!motsParLongueur.ContainsKey(mot.Length)) return false;

            List<string> mots = motsParLongueur[mot.Length];

            if (fin == -1)
            {
                fin = mots.Count - 1;
            }

            if (deb > fin) return false;

            int mil = (deb + fin) / 2;

            if (mot == mots[mil]) return true;

            if (String.Compare(mot, mots[mil]) < 0)
            {
                return RechercheDichoRecursif(mot, deb, mil - 1);
            }
            else
            {
                return RechercheDichoRecursif(mot, mil + 1, fin);
            }
        }
        public bool Contains(string mot)
        {
            // on suppose que le dictionnaire est dans l'ordre alphabétiqeu donc trié
            return RechercheDichoRecursif(mot);
        }

        #endregion Methodes;
    }
}
