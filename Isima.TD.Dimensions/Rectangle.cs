using System;

namespace Isima.TD.Dimensions
{
    public struct Rectangle : IFormePlane
    {
        public double Largeur;
        public double Longueur;

        public Rectangle(double largeur, double longueur)
        {
            Largeur = largeur;
            Longueur = longueur;
        }

        public double Surface
        {
            get { return Largeur * Longueur; }
        }

        public double Perimetre
        {
            get { return Largeur * Longueur * 2; }
        }
    }
}
