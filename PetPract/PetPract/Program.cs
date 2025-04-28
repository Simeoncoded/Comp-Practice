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
                    DisplayAnimals();
                }
                else if (choice == "N")
                {
                    AddAnimal();
                }
                else if (choice == "C")
                {
                    CheckoutPet();
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
                Console.WriteLine("Enter Pet Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Species (Dog, Cat, Bird, etc.): ");
                string species = Console.ReadLine();

                
                string newId = GetNextId(); // Auto-generate padded 8-digit ID

                Pet pet = new Pet(newId, name,species,DateTime.Now,false);


                pets.Add(pet);
                AddAnimalToFile(pet);

                Console.WriteLine("Pet added successfully!\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void DisplayAnimals()
        {
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("No pets found.");
                }
                else
                {
                    Console.WriteLine("Pets in the system:\n");
                    Console.WriteLine(text);
                }
            }
            else
            {
                Console.WriteLine("Pet file not found.");
            }
        }

        static void CheckoutPet()
        {
            try
            {
                Console.Write("Enter the ID of the pet you want to checkout: ");
                string idToRemove = Console.ReadLine();

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Pet file not found.");
                    return;
                }

                var lines = File.ReadAllLines(filePath).ToList();
                var animalIndex = lines.FindIndex(line => line.StartsWith(idToRemove + ","));

                if (animalIndex == -1)
                {
                    Console.WriteLine("Pet with that ID was not found.");
                    return;
                }

                var currentDetails = lines[animalIndex];

                Console.WriteLine($"\nAre you sure you want to checkout this pet?\n{currentDetails}");
                Console.Write("Press Y to confirm, N to cancel: ");
                string rAnswer = Console.ReadLine().ToUpper();
                if (rAnswer == "Y")
                {

                    var parts = lines[animalIndex].Split(',');

                    // Assuming your pet class looks something like: 
                    // ID, Name, Species, Breed, Age, CheckInTime, IsCheckedOut
                    // and IsCheckedOut is the 6th (index 6) or 7th column (index 6 if starting at 0)

                    parts[4] = "true"; // or "true", depending how you save it

                    // Rebuild the line
                    lines[animalIndex] = string.Join(",", parts);

                    // Save all lines back to the file
                    File.WriteAllLines(filePath, lines);

                    Console.WriteLine("Pet checked out successfully!\n");

                }
                else if (rAnswer == "N")
                {
                    Console.WriteLine("Operation cancelled. Pet was not checked out.\n");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.\n");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
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
            string line = $"Pet ID: {pet.ID}, Pet Name: {pet.Name}, Pet Specie: {pet.Species}, Check-In Time: {pet.CheckInTime}, Checked-Out: {pet.isCheckedOut}";

            File.AppendAllText(filePath, line + Environment.NewLine);
        }
    }
}
