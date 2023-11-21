using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA231121
{
    internal class JatekosLovese
    {
        public static (double X, double Y) Cel = (0f, 0f);

        public int LovesSorszam { get; set; }
        public string Nev { get; set; }
        public (double X, double Y) Loves { get; set; }
        public double Tavolsag
        {
            get
            {
                double dx = Cel.X - Loves.X;
                double dy = Cel.Y - Loves.Y;
                return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            }
        }

        public double Pontszam
        {
            get
            {
                double psz = Math.Round(10 - Tavolsag, 2);
                return psz > 0 ? psz : 0d;
            }
        }

        public JatekosLovese(string sor, int sorszam)
        {
            LovesSorszam = sorszam;
            var v = sor.Split(';');
            Nev = v[0];
            Loves = (double.Parse(v[1]), double.Parse(v[2]));
        }
    }
}
