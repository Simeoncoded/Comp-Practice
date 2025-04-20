using System;
using System.Collections.Generic;
using System.IO;

namespace ClassPrac
{
    internal class Program
    {
        static List<Animal> animals = new List<Animal>();
        static string filePath = "animals.txt";

        static void Main(string[] args)
        {
            AddAnimal(); // Add a sample animal
            DisplayAnimals(); // Show all animals

            Console.ReadLine();
        }

        static void AddAnimal()
        {
            Animal animal = new Animal("00000001", "Dog", 'M', true, "Collie", "Brown",
                                       new DateTime(2018, 5, 23), "Up to date", "Micro-chipped",
                                       "MC12345678", 200);
            animals.Add(animal);
            AddAnimalToFile(animal); // Save to file too
        }

        static void DisplayAnimals()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.ID} - {animal.Species} - {animal.Breed}");
            }
        }

        public static void AddAnimalToFile(Animal animal)
        {
            string line = $"{animal.ID},{animal.Species},{animal.Gender},{animal.IsSpayed}," +
                          $"{animal.Breed},{animal.Colour},{animal.Birthday.ToShortDateString()}," +
                          $"{animal.VaccineStatus},{animal.IdentificationType},{animal.IdentificationNumber}," +
                          $"{animal.AdoptionFee}";

            File.AppendAllText(filePath, line + Environment.NewLine);
        }
    }
}
