using System;

namespace Projet
{
    public class D�
    {

        #region Attributs
        private readonly char[] lettresDe;
        private int faceVisible;
        #endregion Attributs

        #region Constructeur
        public D�()
        {
            char[] lettresDe = new char[6]; /// tableau de caract�res
            this.lettresDe = lettresDe; /// position dans le tableau de la lettre qui sera la face visible du d�

            List<char> alphabet = LettresFichiers("Lettres.txt");
            RemplirDe(alphabet);

            Lance();
        }
        #endregion Constructeur

        #region Proprietes
        public char[] LettresDe
        {
            get { return lettresDe; }
        }

        public int FaceVisible
        {
            get { return faceVisible; }
            set { faceVisible = value; }
        }
        #endregion Proprietes


        #region Methodes
        private List<char> LettresFichiers(string filename) /// extrait les lettres du fichiers
        {
            if (filename == null || filename.Length == 0) { throw new Exception("Le fichier rentr� est invalide."); }

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
        ///  Remplit le d� al�atoirement avec � partir du jeu de lettres
        {
            if (alphabet == null || alphabet.Count() == 0) { throw new Exception("L'alphabet est invalide"); }
            bool full = true;
            int n = alphabet.Count - 1;
            for (int i = 0; i < 6; i++)
            {
                Random r = new Random();
                int posLettreTiree = r.Next(0, n);
                lettresDe[i] = alphabet[posLettreTiree]; /// remplissage du d�
            }

            for (int i = 0; i < 6; i++)
            {
                if (lettresDe[i] == ' ') { full = false; } /// on v�rifie que le tableau soit rempli enti�rement, pas de vides
            }
            return full;
        }

        public void Lance()
        {
            Random r = new Random();
            int i = r.Next(0, 6);
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
        #endregion Methodes
    }
}