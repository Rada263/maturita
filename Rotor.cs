using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Sifrovani_rotor
{
    public class Rotor
    {
        public int[] pole = new int[10];
        public int index = 0;

        public Rotor()
        {
            for (index = 0; index < 10; index++)
            {
                pole[index] = 0;
            }
            index = 0;
        }
        public Rotor(int a, int b, int c, int d, int e, int f, int g, int h, int i, int j,int idx)
        {
            pole[0] = a;
            pole[1] = b;
            pole[2] = c;
            pole[3] = d;
            pole[4] = e;
            pole[5] = f;
            pole[6] = g;
            pole[7] = h;
            pole[8] = i;
            pole[9] = j;
            index = idx;
        }
        public void Insert()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Zadejte číslo pro {0}.pozici:", i);
                if (int.TryParse(Console.ReadLine(), out int cislo))
                {
                    if (cislo >= 0 && cislo < 10)
                        pole[i] = cislo;
                    else
                        i --;
                }
            }
        }
        public bool Move_idx()
        {
            index++;
            if (index > 9)
            {
                index = 0;
                return true;
            }
            else
                return false;
        }
        public int Get_val()
        {
            return pole[index];
        }
    }
    internal class Program
    {
        static Rotor A = new Rotor(0, 3, 2, 1, 8, 5, 7, 4, 6, 9, 2);
        static Rotor B = new Rotor(2, 8, 4, 6, 5, 1, 3, 5, 7, 0, 4);
        static void Main(string[] args)
        {
            Console.Write("Prosím slovo na zašifrování:");
            string text = Sifrovani(Console.ReadLine());
            Console.WriteLine("Šifrované: " + text);
            A = new Rotor(0, 3, 2, 1, 8, 5, 7, 4, 6, 9, 2);
            B = new Rotor(2, 8, 4, 6, 5, 1, 3, 5, 7, 0, 4);
            string text2 = Desifrovani(text);
            Console.WriteLine("Dešifrované: " + text2);
            Console.ReadLine();
        }
        static string Sifrovani(string x)
        {
            char z;
            string full = "";
            foreach (char c in x)
            {
                z = (char)((int)c + ((2 * A.Get_val()) - B.Get_val()));
                if (A.Move_idx())
                    B.Move_idx();
                full += z;
            }
            return full;
        }
        static string Desifrovani(string text)
        {
            char z;
            string full = "";
            foreach (char c in text)
            {
                z = (char)((int)c - ((2 * A.Get_val()) - B.Get_val())); 
                if (A.Move_idx())
                    B.Move_idx();
                full += z;
            }
            return full; 
        }
    }
}
