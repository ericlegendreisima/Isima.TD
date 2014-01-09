using System;

namespace Isima.TD.Dimensions
{
    public struct Cercle : IFormePlane
    {
        public double Rayon;

        public Cercle(double rayon)
        {
            Rayon = rayon;
        }

        public double Surface
        {
            get { return Math.PI * Rayon * Rayon; }
        }

        public double Perimetre
        {
            get { return Math.PI * 2 * Rayon; }
        }
    }
}
