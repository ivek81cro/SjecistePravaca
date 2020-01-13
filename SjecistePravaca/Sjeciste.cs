using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_lines
{
    public class Tocka
    {
        public double X;
        public double Y;
    }
    class Sjeciste
    {
        public Tocka IzracunajSjeciste(LineEquation le1, LineEquation le2)
        {
            Tocka p = new Tocka();
            double d = le1.A * le2.B - le2.A * le1.B;

            p.X = Math.Round((le2.B * le1.C - le1.B * le2.C) / d, 4);
            p.Y = Math.Round((le1.A * le2.C - le2.A * le1.C) / d, 4);

            return p;
        }
    }
}
