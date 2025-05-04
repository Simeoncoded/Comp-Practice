using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacPrac
{
   
    internal class Program
    {
        static List<Vac> vac = new List<Vac>();

        static string filepath = "vac.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("\n Welcome to Vac app \n");
            Console.WriteLine("\nPress A to add new Animal\n");
            Console.WriteLine("\nPress M to mark animal as vaccinated\n");
            Console.WriteLine("\nPress V to view All Animal\n");
            Console.WriteLine("\nPress E to exit app\n");
            Console.Write("Your Choice: ");

            bool exit = false;

            while (!exit) { 
               string choice = Console.ReadLine().ToUpper();

                if (choice == "A")
                {

                }else if(choice == "M")
                {

                }else if(choice == "V")
                {

                }else if(choice == "E")
                {
                    exit = true;
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

            }

            
        }
        public static void AddAnimalToFile(Vac vac)
        {
            string line = $"{vac.ID},{vac.Name},{vac.Species},{vac.isVaccinated},{vac.ValDate}";

            File.AppendAllText(filepath, line + Environment.NewLine);
        }
    }
}
