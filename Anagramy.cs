using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Policy;
using System.ComponentModel.Design;

namespace Anagramy_Palindromy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("### VYBER SI Z MENU ###");
            Console.WriteLine("1 - Anagramy");
            Console.WriteLine("2 - Palindrom");

            int vyber = int.Parse(Console.ReadLine());
            switch (vyber)
            {
                case 1:
                    Anagramy();
                    break;
                case 2:
                    Palindram();
                    break;
            }
        }

        static void Palindram()
        {
            Console.Write("Zadej slovo X: ");
            string X = Console.ReadLine();
            string reversed = "";

            foreach (char c in X) reversed = c + reversed;
            if (X == reversed) Console.WriteLine("Je palindrom kekw");
            else Console.WriteLine("Není palindrom");
            Console.ReadLine();
        }

        static void Anagramy()
        {

            Console.Write("Zadej slovo A: ");
            string A = Console.ReadLine();

            Console.Write("Zadej slovo B: ");
            string B = Console.ReadLine();

            Console.WriteLine("Zadaná slova:" + A + " a " + B);
            Console.ReadLine();
            Console.Clear();

            int Delka_A = A.Length;
            int Delka_B = B.Length;
            bool isanagram = true;

            if (Delka_A != Delka_B) Console.WriteLine("Error");
            else
            {
                int[] Hist_A = new int[256];
                int[] Hist_B = new int[256];

                for (int i = 0; i < Delka_A; i++)
                {
                    Hist_A[A[i]]++;
                    Hist_B[B[i]]++;
                }

                for (int j = 0; j < 256; j++)
                {
                    if (Hist_A[j] != Hist_B[j]) isanagram = false;
                }

                if (isanagram == false) Console.WriteLine("Daná slova nejsou anagramy.");
                else Console.WriteLine("Jsou anagramy");
                Console.ReadLine();
            }
        }
    }
}
