using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vpct_obs_pd_krivk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vysledek = 0;
            int bodx = 0;
            double krok = 0.01;
            double[] tabulka = new double[158];
            for (double x = krok; x < (Math.PI / 2); x += krok)
            {
                double predeslex = x - krok;
                double y = Math.Sin(x);
                double predesley = Math.Sin(predeslex);
                double pocet = ((x - predeslex) * predesley) + (((x - predeslex) * (y - predesley)) / 2);
                vysledek += pocet;
                tabulka[bodx] = vysledek;
                bodx++;
                Console.WriteLine("x = {0:F2} y = {1}", x, y);
            }
            Console.WriteLine("-------------------------------\nOBSAH = {0}", vysledek);
            Console.ReadLine();
        }
    }
}
