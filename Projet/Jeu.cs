using static Projet.De;
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
        private DateTime heureDebut;
        private int tempsRestant;

        public Jeu(Joueur joueur1, Joueur joueur2, Plateau plateau, DateTime heureDebut)
        {
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            this.plateau = plateau;
            this.heureDebut = heureDebut;
            TimeSpan diffSecondes = heureDebut - DateTime.Now;
            this.tempsRestant = Convert.ToInt32(diffSecondes);
        }


    } 
}