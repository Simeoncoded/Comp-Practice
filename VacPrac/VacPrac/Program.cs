﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacPrac
{
   
    internal class Program
    {
        static List<Vac> vacs = new List<Vac>();

        static string filepath = "vac.txt";
        static void Main(string[] args)
        {
         
            bool exit = false;

            while (!exit) {
                Console.WriteLine("\n Welcome to Vac app \n");
                Console.WriteLine("\nPress A to add new Animal\n");
                Console.WriteLine("\nPress M to mark animal as vaccinated\n");
                Console.WriteLine("\nPress V to view All Animal\n");
                Console.WriteLine("\nPress E to exit app\n");
                Console.Write("Your Choice: ");


                string choice = Console.ReadLine().ToUpper();

                if (choice == "A")
                {
                    AddAnimal();
                }else if(choice == "M")
                {
                    MarkPet();
                }else if(choice == "V")
                {
                    ViewAnimals();
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

        static string GenId()
        {
            if(!File.Exists(filepath))
            {
                return "00000001";
            }

            var lines = File.ReadAllLines(filepath);

            if(lines.Length == 0 )
            {
                return "00000001";
            }

            var lastline = lines.Last();
            var lastid = lastline.Split(',')[0];

            int nextid = int.Parse(lastid) + 1;
            return nextid.ToString("D8");

        }

    static void AddAnimal()
        {
            Console.WriteLine("Enter Name: ");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter Specie: ");
            string Specie = Console.ReadLine();

            string newId = GenId();

            Vac vac = new Vac(newId, Name,Specie,false,DateTime.MinValue);

            vacs.Add(vac);
            AddAnimalToFile(vac);

            Console.WriteLine("Animal added successfully");
        }

        static void MarkPet()
        {
            Console.WriteLine("Enter the ID of the pet you want to mark as vaccinated:");
            string idToUpdate = Console.ReadLine();

            if (!File.Exists(filepath))
            {
                Console.WriteLine("Animal file not found.");
                return;
            }

            // Load all lines from the file
            var lines = File.ReadAllLines(filepath).ToList();

            // Find the line to update
            var index = lines.FindIndex(line => line.StartsWith(idToUpdate + ","));

            if (index == -1)
            {
                Console.WriteLine("Animal ID not found.");
                return;
            }

            // Parse the line and update the archive status
            var parts = lines[index].Split(',');

            if (parts.Length < 5 || parts[3].ToLower() == "true")
            {
                Console.WriteLine("Animal not found or already archived.");
                return;
            }

            parts[3] = "true"; // Set archived to true

            // Reconstruct the line
            lines[index] = string.Join(",", parts);

            // Write the updated list back to the file
            File.WriteAllLines(filepath, lines);

            // Update in-memory list as well (if needed)
            var pet = vacs.FirstOrDefault(p => p.ID == idToUpdate);
            if (pet != null)
            {
                pet.isVaccinated = true;
            }

            Console.WriteLine("Animal marked as vaccinated successfully.");
        }

        static void ViewAnimals()
        {
            if (File.Exists(filepath))
            {
                string text = File.ReadAllText(filepath);

                if (text == "")
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

        public static void AddAnimalToFile(Vac vac)
        {
            string line = $"{vac.ID},{vac.Name},{vac.Species},{vac.isVaccinated},{vac.ValDate}";

            File.AppendAllText(filepath, line + Environment.NewLine);
        }
    }
}
