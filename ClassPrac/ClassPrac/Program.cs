using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassPrac
{
    internal class Program
    {
        static List<Animal> animals = new List<Animal>();
        static string filePath = "animals.txt";

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nHi — welcome to this animal app!");
                Console.WriteLine("Press D to display all animals sorted by species");
                Console.WriteLine("Press N to add a new animal");
                Console.WriteLine("Press U to update an animal");
                Console.WriteLine("Press R to remove an animal");
                Console.WriteLine("Press Q to quit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine().ToUpper();

                if (choice == "D")
                {
                    DisplayAnimals();
                }
                else if (choice == "N")
                {
                    AddAnimal();
                }
                else if (choice == "U")
                {
                    UpdateAnimal();
                }
                else if (choice == "R")
                {
                    RemoveAnimal();
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






        static void AddAnimal()
        {
            try
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

                string newId = GetNextId(); // Auto-generate padded 8-digit ID

                Animal animal = new Animal(newId, species, gender, isSpayed, breed, colour, birthday,
                                            vaccineStatus, idType, idNo, adoptionFee);

                animals.Add(animal);
                AddAnimalToFile(animal);

                Console.WriteLine("Animal added successfully!\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void UpdateAnimal()
        {
            Console.Write("Enter the ID of the animal you want to update: ");
            string idToUpdate = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Animal file not found.");
                return;
            }

            var lines = File.ReadAllLines(filePath).ToList();
            var animalIndex = lines.FindIndex(line => line.StartsWith(idToUpdate + ","));

            if (animalIndex == -1)
            {
                Console.WriteLine("Animal with that ID was not found.");
                return;
            }

            var currentDetails = lines[animalIndex].Split(',');

            Console.WriteLine($"Current Species: {currentDetails[1]} — Enter new or leave blank to keep:");
            string species = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(species)) species = currentDetails[1];

            Console.WriteLine($"Current Gender: {currentDetails[2]} — Enter new (M/F) or leave blank:");
            string genderInput = Console.ReadLine();
            char gender = string.IsNullOrWhiteSpace(genderInput) ? Convert.ToChar(currentDetails[2]) : Convert.ToChar(genderInput.ToUpper());

            Console.WriteLine($"Current Is Spayed: {currentDetails[3]} — Enter new (true/false) or leave blank:");
            string spayedInput = Console.ReadLine();
            bool isSpayed = string.IsNullOrWhiteSpace(spayedInput) ? Convert.ToBoolean(currentDetails[3]) : Convert.ToBoolean(spayedInput);

            Console.WriteLine($"Current Breed: {currentDetails[4]} — Enter new or leave blank:");
            string breed = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(breed)) breed = currentDetails[4];

            Console.WriteLine($"Current Colour: {currentDetails[5]} — Enter new or leave blank:");
            string colour = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(colour)) colour = currentDetails[5];

            Console.WriteLine($"Current Birthday: {currentDetails[6]} — Enter new (yyyy-mm-dd) or leave blank:");
            string birthdayInput = Console.ReadLine();
            DateTime birthday = string.IsNullOrWhiteSpace(birthdayInput) ? DateTime.Parse(currentDetails[6]) : DateTime.Parse(birthdayInput);

            Console.WriteLine($"Current Vaccine Status: {currentDetails[7]} — Enter new or leave blank:");
            string vaccineStatus = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(vaccineStatus)) vaccineStatus = currentDetails[7];

            Console.WriteLine($"Current ID Type: {currentDetails[8]} — Enter new or leave blank:");
            string idType = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idType)) idType = currentDetails[8];

            Console.WriteLine($"Current ID Number: {currentDetails[9]} — Enter new or leave blank:");
            string idNo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idNo)) idNo = currentDetails[9];

            double adoptionFee = CalculateAdoptionFee(birthday);

            // Update line
            string updatedLine = $"{idToUpdate},{species},{gender},{isSpayed},{breed},{colour}," +
                                 $"{birthday.ToShortDateString()},{vaccineStatus},{idType},{idNo},{adoptionFee}";

            lines[animalIndex] = updatedLine;

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Animal updated successfully!\n");
        }

        static void RemoveAnimal()
        {
            Console.Write("Enter the ID of the animal you want to remove: ");
            string idToRemove = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Animal file not found.");
                return;
            }

            var lines = File.ReadAllLines(filePath).ToList();
            var animalIndex = lines.FindIndex(line => line.StartsWith(idToRemove + ","));

            if (animalIndex == -1)
            {
                Console.WriteLine("Animal with that ID was not found.");
                return;
            }

            var currentDetails = lines[animalIndex];

            Console.WriteLine($"\nAre you sure you want to remove this animal?\n{currentDetails}");
            Console.Write("Press Y to confirm, N to cancel: ");
            string rAnswer = Console.ReadLine().ToUpper();
            if (rAnswer == "Y")
            {
                lines.RemoveAt(animalIndex);
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Animal removed successfully!\n");
            }
            else if (rAnswer == "N")
            {
                Console.WriteLine("Operation cancelled. Animal was not removed.\n");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter Y or N.\n");
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


        static double CalculateAdoptionFee(DateTime birthday)
        {
            int age = DateTime.Now.Year - birthday.Year;
            if (birthday > DateTime.Now.AddYears(-age)) age--;

            if (age < 1) return 300;
            else if (age > 10) return 100;
            else return 200;
        }

        //method to display all animals
        static void DisplayAnimals()
        {
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("No animals found.");
                }
                else
                {
                    Console.WriteLine("Animals in the system:\n");
                    Console.WriteLine(text);
                }
            }
            else
            {
                Console.WriteLine("Animal file not found.");
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
