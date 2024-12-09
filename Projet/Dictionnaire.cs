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

        public bool Contains(string mot)
        {
            bool trouve = false; // en récursif ?
            int i = 0;
            while (trouve == false && i < mots.Length)
            {
                if (mots[i] == mot) { trouve = true; }
                i++;
            }
            return trouve;
        }

        public void LireMots()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(mots[i] + " ");
            }
            Console.WriteLine(langue);
        }


    }
}