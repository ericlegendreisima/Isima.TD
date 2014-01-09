using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isima.TD.Dimensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            IFormePlane[] formes = new IFormePlane[2];
            formes[0] = new Rectangle(10, 20);
            formes[1] = new Cercle(30);

            for (int i = 0; i < formes.Length; i++)
            {
                Console.WriteLine("Avant [{0}]: surface={1} périmètre={2}", formes[i].GetType().Name, formes[i].Surface, formes[i].Perimetre);

                if (formes[i] is Rectangle)
                    Agrandir((Rectangle)formes[i], 2);
                else if (formes[i] is Cercle)
                    Agrandir((Cercle)formes[i], 2);

                Console.WriteLine("Après [{0}]: surface={1} périmètre={2}", formes[i].GetType().Name, formes[i].Surface, formes[i].Perimetre);

                Console.WriteLine();
            }
        }

        static void Agrandir(Rectangle r, double ratio)
        {
            r.Largeur *= ratio;
            r.Longueur *= ratio;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Calcul : surface={0} périmètre={1}", r.Surface, r.Perimetre);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Agrandir(Cercle c, double ratio)
        {
            c.Rayon *= ratio;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Calcul : surface={0} périmètre={1}", c.Surface, c.Perimetre);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
