using SixLabors.ImageSharp;
using SkiaSharp;
using System;
using System.Collections.Generic;
using static Projet.Jeu;

namespace Projet
{
    public class NuageDePoints
    {
        public static int CalculerScore(string mot)
        {
            return 10*mot.Length;
        }
        public static void Genere(List<string> mots)
        {
            /// Liste de mots pour le nuage avec leurs scores.

            /// Dictionnaire pour stocker les mots et leurs tailles (scores).
            var motsScores = new Dictionary<string, int>();
            foreach (var mot in mots)
            {
                motsScores[mot] = CalculerScore(mot);
            }

            /// Créer l'image du nuage de mots.
            int largeur = 800;
            int hauteur = 600;
            using var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur));
            var canvas = surface.Canvas;

            /// Remplir le fond avec une couleur.
            canvas.Clear(SKColors.White);

            /// Générer les textes du nuage de mots.
            var random = new Random();
            foreach (var mot in motsScores)
            {
                int taillePolice = mot.Value; /// Taille en fonction du score.

                /// Couleur aléatoire pour chaque mot.
                var couleur = new SKColor(
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256));

                /// Calculer les limites pour la position.
                int maxX = Math.Max(largeur - taillePolice * mot.Key.Length / 2, 1);
                int maxY = Math.Max(hauteur - taillePolice, 1);

                /// Position aléatoire sur le canevas (assurez-vous que maxX > 0 et maxY > 0).
                int x = random.Next(0, maxX);
                int y = random.Next(0, maxY);

                /// Définir les paramètres du texte.
                using var paint = new SKPaint
                {
                    Color = couleur,
                    TextSize = taillePolice,
                    IsAntialias = true
                };

                /// Dessiner le texte sur le canevas.
                canvas.DrawText(mot.Key, x, y + taillePolice, paint);
            }


            /// Enregistrer le nuage de mots dans un fichier image.
            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            System.IO.File.WriteAllBytes("nuage_de_mots.png", data.ToArray());

            Console.WriteLine("Nuage de mots généré et enregistré sous 'nuage_de_mots.png'");
        }
    }

}
