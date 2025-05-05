using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPract
{
    internal class Program
    {
        static List<Final> finals = new List<Final>();
        static string filepath = "finals.txt";
        static void Main(string[] args)
        {
            bool exit = false;

            while(!exit)
            {
                Console.WriteLine("Welcome to the Animals App");
                Console.WriteLine("Please enter A to add a new Animal");
                Console.WriteLine("Please enter U to update an Animal by ID");
                Console.WriteLine("Please enter D to delete an Animal by ID");
                Console.WriteLine("Please enter V to view all Animals");
                Console.WriteLine("Please enter E to exit App");
                Console.Write("Your Choice: ");
                string choice = Console.ReadLine().ToUpper();

                if(choice == "A")
                {
                    AddNewAnimal();
                }else if(choice == "U")
                {
                    
                }else if(choice == "D") { 

                }else if(choice == "V")
                {
                    ViewAnimals();
                }else if(choice == "E")
                {
                    exit = true;
                    return;
                }

            }
        }

        public static void AddNewAnimal()
        {
            try
            {
                string id = GenID();

                Console.Write("Enter Species (Dog, Cat, Bird, etc.): ");
                string species = Console.ReadLine();

                Console.Write("Enter Gender (M/F): ");
                char gender = Console.ReadLine().ToUpper()[0];

                Console.Write("Is the animal injured? (yes/no): ");
                bool isInjured = Console.ReadLine().Trim().ToLower() == "yes";

                Console.Write("Enter Breed: ");
                string breed = Console.ReadLine();

                Console.Write("Enter Color: ");
                string color = Console.ReadLine();

                Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Arrival Date (yyyy-mm-dd): ");
                DateTime arrivalDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Identification (Barcode/Microchip number): ");
                string identification = Console.ReadLine();

                Console.Write("Vaccination Status (UptoDate, Late, Unknown): ");
                Vaccination vaccination = (Vaccination)Enum.Parse(typeof(Vaccination), Console.ReadLine(), true);

                Console.Write("Current Status (Available, Adopted, Archived): ");
                Status status = (Status)Enum.Parse(typeof(Status), Console.ReadLine(), true);

                Console.Write("Is the animal spayed or neutered? (yes/no): ");
                bool isSpayed = Console.ReadLine().Trim().ToLower() == "yes";

                // Create the animal object (no need to pass adoptionFee as it's calculated)
                Final animal = new Final(
                    id, species, gender, isInjured, breed, color, dob, arrivalDate,
                    identification, vaccination, status, isSpayed
                );

                // Add to file
                AddAnimalToFile(animal);
                Console.WriteLine("Animal added successfully!");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
         
        }

        static void ViewAnimals()
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string text = File.ReadAllText(filepath);

                    if (text == "")
                    {
                        Console.WriteLine("No Animals found in the file");
                    }
                    else
                    {
                        Console.WriteLine("Animals in the System\n");
                        Console.WriteLine(text);
                    }
                }
                else
                {
                    Console.WriteLine("File not found");
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
            }
           
        }

        static string GenID()
        {
            if (!File.Exists(filepath))
            {
                return "00000001";
            }

            var lines = File.ReadAllLines(filepath);

            if (lines.Length == 0)
            {
                return "00000001";
            }

            var lastline = lines.Last();
            var lastid = lastline.Split(',')[0];

            int nextid = int.Parse(lastid) + 1;
            return nextid.ToString("D8");
        }

        public static void AddAnimalToFile(Final final)
        {
            string line = $"{final.Id},{final.Species},{final.Gender},{final.IsInjured},{final.Breed},{final.Color},{final.DOB},{final.ArrivalDate},{final.Identification}," +
                $"{final.Vaccination},{final.Status},{final.IsSpayedOrNeutered},{final.AdoptionFee}";

            File.AppendAllText(filepath, line + Environment.NewLine);
        }
    }
}
