using System;
using System.Collections.Generic;
using System.IO;
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


        static string GetNextId()
        {
            // If the file doesn't exist yet, start from 1
            if (!File.Exists(filePath))
                return "00000001";

            var lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
                return "00000001";

            // Get the last used ID (from the last line)
            var lastLine = lines.Last();
            var lastId = lastLine.Split(',')[0];

            // Convert to int, add 1, then format it back to 8 digits
            int nextIdNum = int.Parse(lastId) + 1;
            return nextIdNum.ToString("D8");
        }

        public static void AddAnimalToFile(Pet pet)
        {
            string line = $"{pet.ID},{pet.Species},{pet.CheckInTime == DateTime.Now}";

            File.AppendAllText(filePath, line + Environment.NewLine);
        }
    }
}
