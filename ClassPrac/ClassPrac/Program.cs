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
            Console.WriteLine("Enter Species (Dog, Cat, Bird, etc.): ");
            string species = Console.ReadLine();

            Console.WriteLine("Enter Gender (M/F): ");
            char gender = Convert.ToChar(Console.ReadLine().ToUpper());

            Console.WriteLine("Is Spayed (true/false): ");
            bool isSpayed = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Enter Breed: ");
            string breed = Console.ReadLine();

            Console.WriteLine("Enter Colour: ");
            string colour = Console.ReadLine();

            Console.WriteLine("Enter Birthday (yyyy-mm-dd): ");
            DateTime birthday = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Vaccine Status (Up to date, Late, Unknown): ");
            string vaccineStatus = Console.ReadLine();

            Console.WriteLine("Enter Identification Type (Micro-chipped/Bar code): ");
            string idType = Console.ReadLine();

            Console.WriteLine("Enter Identification Number: ");
            string idNo = Console.ReadLine();

            double adoptionFee = CalculateAdoptionFee(birthday);

            string newId = (animals.Count + 1).ToString("D8"); // Auto-generate padded 8-digit ID

            Animal animal = new Animal(newId, species, gender, isSpayed, breed, colour, birthday,
                                        vaccineStatus, idType, idNo, adoptionFee);

            animals.Add(animal);
            AddAnimalToFile(animal);

            Console.WriteLine("Animal added successfully!\n");
        }

        static double CalculateAdoptionFee(DateTime birthday)
        {
            int age = DateTime.Now.Year - birthday.Year;
            if (birthday > DateTime.Now.AddYears(-age)) age--;

            if (age < 1) return 300;
            else if (age > 10) return 100;
            else return 200;
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
