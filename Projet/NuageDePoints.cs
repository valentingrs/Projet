using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

class NuageDeMots
{
    public static int CalculScore(string mot)
    {
        // Exemple de fonction pour calculer un score
        return mot.Length * 10; // Score basé sur la longueur du mot
    }

    public static void GenererNuageDeMots(List<string> mots)
    {
        // Créer une image et un objet Graphics
        int largeurImage = 800;
        int hauteurImage = 600;
        Bitmap image = new Bitmap(largeurImage, hauteurImage);
        Graphics g = Graphics.FromImage(image);

        // Définir le fond de l'image
        g.Clear(Color.White);

        // Liste de mots avec leurs scores
        List<KeyValuePair<string, int>> motsAvecScores = mots.Select(mot => new KeyValuePair<string, int>(mot, CalculScore(mot))).ToList();

        // Normaliser la taille des mots en fonction de leur score
        int scoreMax = motsAvecScores.Max(m => m.Value);
        int scoreMin = motsAvecScores.Min(m => m.Value);
        Font font;
        Random random = new Random();

        // Dessiner chaque mot avec une taille proportionnelle à son score
        foreach (var motScore in motsAvecScores)
        {
            string mot = motScore.Key;
            int score = motScore.Value;

            // Calculer la taille du mot sur la base du score
            float taille = 10 + (score - scoreMin) * 30 / (float)(scoreMax - scoreMin);
            font = new Font("Arial", taille);

            // Positionner aléatoirement le mot sur l'image
            int x = random.Next(largeurImage - (int)(taille * mot.Length));
            int y = random.Next(hauteurImage - (int)taille);

            // Dessiner le mot
            g.DrawString(mot, font, Brushes.Black, new PointF(x, y));
        }

        // Sauvegarder l'image
        image.Save("nuage_de_mots.png");
        Console.WriteLine("Nuage de mots généré et sauvegardé sous 'nuage_de_mots.png'.");
    }

    public void Genere(List<string> mots)
    {
        // Générer et afficher le nuage de mots
        GenererNuageDeMots(mots);
    }
}
