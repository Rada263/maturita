using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kolonie
{
    internal class Program
    {
        public class Kolonie
        {
            public int[,] pole = new int[40, 20];
            public int seed = 0;
            public int generation = 0;

            public void Pole_set()
            {
                Random random = new Random(seed);
                for (int x = 0; x < 40; x++)
                    for (int y = 0; y < 20; y++)
                    {
                        int num = random.Next(0, 101);
                        if (num >= 85)
                            pole[x, y] = 1;
                        else
                            pole[x, y] = 0;
                    }
            }
            public void Zobrazit(int offset, ConsoleColor clr)
            {
                Console.SetCursorPosition(3 + offset, 22);
                Console.WriteLine("                                                                         ");
                Console.ForegroundColor = clr;
                for (int x = 0; x < 40; x++)
                    for (int y = 0; y < 20; y++)
                    {
                        Console.SetCursorPosition(x + offset, y);
                        if (pole[x, y] == 1)
                            Console.Write("X");
                        else
                            Console.Write(".");
                    }
                Console.SetCursorPosition(3 + offset, 22);
                Console.WriteLine("Počet buněk: " + Pocet_Bunek() + "  Generace: " + generation);
            }
            public int Pocet_sousedu(int x, int y)
            {
                int pocet = 0;
                    if (x != 0 && y != 0)
                        if (pole[x - 1, y - 1] == 1) pocet++;
                    if (y != 0)
                        if (pole[x, y - 1] == 1) pocet++;
                    if (y != 0 && x < 39)
                        if (pole[x + 1, y - 1] == 1) pocet++;
                    if (x != 0)
                        if (pole[x - 1, y] == 1) pocet++;
                    if (x < 39)
                        if (pole[x + 1, y] == 1) pocet++;
                    if (x != 0 && y <= 18)
                        if (pole[x - 1, y + 1] == 1) pocet++;
                    if (y <= 18)
                        if (pole[x, y + 1] == 1) pocet++;
                    if (y <= 18 && x < 39)
                        if (pole[x + 1, y + 1] == 1) pocet++;
               return pocet;
            }
            public int Pocet_Bunek()
            {
                int pocet = 0;
                for (int x = 0; x < 40; x++)
                    for (int y = 0; y < 20; y++)
                    {
                        if (pole[x, y] == 1)
                            pocet++;
                    }
                return pocet;
            }
            public void Generace()
            {
                generation++;
                int[,] nove_pole = new int[40, 20];
                for (int x = 0; x < 40; x++)
                    for (int y = 0; y < 20; y++)
                    {
                        int sousede = Pocet_sousedu(x, y);
                        if (pole[x, y] == 1)
                        {
                            if (sousede == 2 || sousede == 3)
                                nove_pole[x, y] = 1;
                            else
                                nove_pole[x, y] = 0;
                        }
                        else
                        {
                            if (sousede == 3)
                                nove_pole[x, y] = 1;
                            else
                                nove_pole[x, y] = 0;
                        }
                    }
                pole = nove_pole;
            }
            static void Main(string[] args)
            {
                Kolonie A = new Kolonie();
                Kolonie B = new Kolonie();
                Console.Write("Zadejte první seed: ");
                A.seed = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.Write("Zadejte druhý seed: ");
                B.seed = int.Parse(Console.ReadLine());
                A.Pole_set();
                B.Pole_set();
                
                while (true)
                {
                    A.Zobrazit(0, ConsoleColor.Magenta);
                    B.Zobrazit(45, ConsoleColor.DarkMagenta); 
                    A.Generace();
                    B.Generace();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
