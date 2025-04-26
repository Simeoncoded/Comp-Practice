using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPract
{
    
    internal class Program
    {
        static List<Pet> pets = new List<Pet>();
        static string filePath = "pets.txt";

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nHi — welcome to this animal app!");
                Console.WriteLine("Press D to display all animals");
                Console.WriteLine("Press N to add new pet");
                Console.WriteLine("Press C to checkout a pet");
                Console.WriteLine("Press Q to quit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine().ToUpper();

                if (choice == "D")
                {
                }
                else if (choice == "N")
                {

                }
                else if (choice == "C")
                {

                }


                else if (choice == "Q")
                {
                    exit = true;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice — try again.");
                }
            }
        }
    }
}
