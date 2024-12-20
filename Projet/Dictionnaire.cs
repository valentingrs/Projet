using static Projet.TestUnitaires;

namespace Projet
{
    public class Dictionnaire
    {
        #region Attributs

        private readonly List<string> mots;
        private Dictionary<int, List<string>> motsParLongueur;
        private Dictionary<char, List<string>> motsParLettres;
        private string langue;

        #endregion Attributs


        #region Constructeur
        public Dictionnaire(string langue) 
        {
            /// en entrée on s'assure déjà que la langue soit bien rentrée
            this.langue = langue;
            this.mots = LireFichierMots($"MotsPossibles{langue.ToUpper()}.txt");
            this.motsParLongueur = TriMotsParLongueur();
            this.motsParLettres = TriMotsParLettre();
        }
        #endregion Constructeur

        #region Proprietes

        public string Langue {
            
            get { return langue; }
            set { langue = value; }
        }

        public List<string> Mots {
            
            get { return mots; }
        }

        #endregion Proprietes

        #region Methodes

        public List<string> LireFichierMots(string filename) {
            
            if (filename == null || filename.Length == 0)
            {
                throw new Exception("fichier rentré invalide");
            }
            List<string> dico = new List<string>();
            string[] lignes = File.ReadAllLines(filename);

            foreach (string line in lignes) {
                
                string[] motsParLigne = line.Split(' ');

                foreach (string mot in motsParLigne) {
                    
                    dico.Add(mot);
                }
            }

            return dico;
        }

        public Dictionary<int, List<string>> TriMotsParLongueur()
        {
            Dictionary<int, List<string>> motsParLongueur = new Dictionary<int, List<string>>();

            foreach (string mot in this.mots) {
                
                int longueur = mot.Length;

                if (!motsParLongueur.ContainsKey(longueur)) /// si dans le dico il n'y a pas cette longueur la
                {
                    motsParLongueur[longueur] = new List<string>(); /// alors on créé une nouvelle liste associée à une nv longuer
                }

                motsParLongueur[longueur].Add(mot); /// on ajoute le mots à la liste de mots 
            }

            /// tri de chaque liste
            foreach (int i in motsParLongueur.Keys)
            {
                TriFusion(motsParLongueur[i]);
            }

            return motsParLongueur;
        }

        public Dictionary<char, List<string>> TriMotsParLettre()
        {
            Dictionary<char, List<string>> motsParLettre = new Dictionary<char, List<string>>();

            foreach (string mot in this.mots)
            {
                char c = mot[0]; /// premier caractère du mot

                if(!motsParLettre.ContainsKey(c)) /// si dans le dico il n'y a pas de mot commencant par cette lettre
                {
                    motsParLettre[c] = new List<string>(); /// alors on créé une nouvelle liste associée à une nv longuer
                }
                motsParLettre[c].Add(mot); /// on ajoute le mots à la liste de mots 
            }

            /// tri de chaque liste
            foreach (char c in motsParLettre.Keys)
            {
                TriFusion(motsParLettre[c]);
            }

            return motsParLettre;
        }

        public string toString()
        {
            string s = "";
        
            for (int i = 2; i <= 24; i++)
            {
                if (motsParLongueur.ContainsKey(i))
                {
                    int occ = motsParLongueur[i].Count;
                    s = s + i + " : " + occ + "; ";
                }
            }
            
            s = s + "\n";
            string alphabet = "AZERTYUIOPQSDFGHJKLMWXCVBN";
            
            foreach (char lettre in alphabet)
            {
                if (motsParLettres.ContainsKey(lettre))
                {
                    int occ = motsParLettres[lettre].Count;
                    s = s + lettre + " : " + occ + " ; ";
                }
            }
            
            return s;
        }

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
                List<string> right = liste.GetRange(mil, liste.Count()-mil);


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

        


        public bool RechercheDichoRecursif(string mot, int deb = 0, int fin = -1)
        {
            if (!motsParLongueur.ContainsKey(mot.Length))
            {                
                return false;
            }


            List<string> mots = motsParLongueur[mot.Length];
            if (!EstTrie(mots)) { throw new Exception("La liste n'est pas triee"); }

            if (fin == -1)
            {
                fin = mots.Count - 1;
            }

            if (deb > fin)
            {                
                return false;
            }


            int mil = (deb + fin) / 2;

            if (mot == mots[mil]) return true;

            if (String.Compare(mot, mots[mil]) < 0) return RechercheDichoRecursif(mot, deb, mil - 1);
            
            else return RechercheDichoRecursif(mot, mil + 1, fin);
        }

        public bool Contains(string mot)
        {
            // on suppose que le dictionnaire est dans l'ordre alphabétiqeu donc trié
            return RechercheDichoRecursif(mot);
        }

        #endregion Methodes;
    }
}