using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostandFoundPrac
{
    internal class Program
    {
        static List<lfound> lfounds = new List<lfound>();
        static string filepath = "pets.txt";
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit) {
                Console.WriteLine("\nWelcome to the Lost and found app");
                Console.WriteLine("Press R to report a lost pet");
                Console.WriteLine("Press F to report a found pet");
                Console.WriteLine("Press U to update a pet");
                Console.WriteLine("Press D to remove a pet");
                Console.WriteLine("Press V to view all pets");
                Console.WriteLine("Press E to exit app");
            }
        }
    }
}
