using System.Diagnostics.CodeAnalysis;
using static Projet.Dé;
using static Projet.Dictionnaire;
using static Projet.Joueur;

namespace Projet
{
    public class Plateau
    {
        #region Attributs

        private Dé[,] plateauDes;
        private char[,] valVisible;
        private Dictionnaire dictionnaire;
        #endregion Attributs

        #region Constructeur
        public Plateau(Dé[,] plateauDes, string langue)
        {
            if (plateauDes.GetLength(0) != plateauDes.GetLength(1))
                throw new ArgumentException("Le plateau doit être de la forme nxn.");

            this.plateauDes = plateauDes;
            this.valVisible = new char[plateauDes.GetLength(0), plateauDes.GetLength(1)];
            this.dictionnaire = new Dictionnaire(langue);

            for (int i = 0; i < plateauDes.GetLength(0); i++)
            {
                for (int j = 0; j < plateauDes.GetLength(1); j++)
                {
                    this.valVisible[i, j] = plateauDes[i,j].LettresDe[plateauDes[i,j].FaceVisible];
                }
            }

        }
        #endregion Constructeur

        #region Propriété

        #endregion Propriété

        #region Méthode

        public override string ToString()
        {
            string plateau = "Le plateau de ce tour est : \n";
            for (int i = 0; i < plateauDes.GetLength(0); i++)
            {
                for (int j = 0; j < plateauDes.GetLength(0); j++)
                {
                    plateau = plateau + valVisible[i, j] + " ";
                }
                plateau += "\n";
            }
            return plateau;
        }

        public void RelancerDes() // relancer les des
        {
            Dé de;
            for (int i = 0; i < plateauDes.GetLength(0); i++)
            {
                for (int j = 0; j < plateauDes.GetLength(1); j++)
                {
                    de = plateauDes[i, j]; // met à jour la face Visible des de
                    de.Lance();
                    valVisible[i, j] = plateauDes[i, j].LettresDe[plateauDes[i, j].FaceVisible]; // maj plateau avec les dés mis à jour

                }
            }
        }

        public bool ContraintePlateau(string mot)
        {
            if (dictionnaire.Contains(mot) && Verif_Plateau(mot)) return true;

            return false;
        }

        public bool Verif_Plateau(string mot)
        {
            bool[,] plateau_de_visite = new bool[plateauDes.GetLength(0), plateauDes.GetLength(0)];

            for (int i = 0; i < plateauDes.GetLength(0); i++)
            {
                for (int j = 0; j < plateauDes.GetLength(0); j++)
                {
                    if (Trouve_mot(valVisible, plateau_de_visite, i, j, mot, 0)) return true;
                }
            }

            return false;
        }
        public bool Trouve_mot(char[,] plateau, bool[,] plateau_de_visite, int i, int j, string mot, int index)
        {
            if (i < 0 || j < 0 || i >= plateau.GetLength(0) || j >= plateau.GetLength(0) || plateau_de_visite[i, j]) return false;

            if (plateau[i, j] != mot[index]) return false;

            if (index == mot.Length - 1) return true;

            plateau_de_visite[i, j] = true;

            for (int ligne = i - 1; ligne <= i + 1; ligne++)
            {
                for (int colonne = j - 1; colonne <= j + 1; colonne++)
                {
                    if (Trouve_mot(plateau, plateau_de_visite, ligne, colonne, mot, index + 1)) return true;
                }
            }

            plateau_de_visite[i, j] = false;

            return false;
        }



        #endregion Methode
    }
}