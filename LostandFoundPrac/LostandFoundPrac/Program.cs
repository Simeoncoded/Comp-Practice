using System;
using System.Collections.Generic;
using System.IO;
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

                Console.Write("Your Choice: ");

                string choice = Console.ReadLine().ToUpper();

                if (choice == "R")
                {
                    ReportLostPet();
                }else if(choice == "F")
                {
                    ReporFoundPet();
                }
                else if (choice == "U")
                {
                   
                }
                else if (choice == "D")
                {

                }
                else if (choice == "V")
                {
                    DisplayAnimals();
                }
                else if (choice == "E")
                {
                    exit = true;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Wrong choice, try again!!");
                }

            }
        }

        static void ReportLostPet()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Specie");
            string specie = Console.ReadLine();

            string newid  = GenId();

            lfound lfound = new lfound(newid,name,specie,Status.lost,DateTime.Today);

            lfounds.Add(lfound);
            AddAnimaltoFile(lfound);

            Console.WriteLine("Pet reported as lost sucessfully");

        }

        static void ReporFoundPet()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Specie");
            string specie = Console.ReadLine();

            string newid = GenId();

            lfound lfound = new lfound(newid, name, specie, Status.found, DateTime.Today);

            lfounds.Add(lfound);
            AddAnimaltoFile(lfound);

            Console.WriteLine("Pet reported as found sucessfully");

        }

        static void DisplayAnimals()
        {
            if (File.Exists(filepath))
            {
                string text = File.ReadAllText(filepath);

                if(text == "")
                {
                    Console.WriteLine("No animals found");
                }
                else
                {
                    Console.WriteLine("Animals in the system:\n");
                    Console.WriteLine(text);
                }

            }
            else
            {
                Console.WriteLine("Animal file not found");
            }
        }

        static string GenId()
        {
            if(!File.Exists(filepath))
            {
                return "00000001";
            }

            var lines = File.ReadAllLines(filepath);

            if(lines.Length == 0)
            {
                return "00000001";
            }

            var lastline = lines.Last();
            var lastid = lastline.Split(',')[0];

            int nextid = int.Parse(lastid) + 1;
            return nextid.ToString("D8");
        }

        public static void AddAnimaltoFile(lfound lfound)
        {
            string line = $"{lfound.id},{lfound.species},{lfound.namae},{lfound.status},{lfound.reporttime.ToShortDateString()}";

            File.AppendAllText(filepath, line + Environment.NewLine);
        }
    }
}
