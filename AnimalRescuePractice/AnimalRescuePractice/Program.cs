using AnimalRescuePractice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string filePath = "animals.txt";

// Load existing animals from file (if any)
List<Animal> animals = LoadAnimalsFromFile(filePath);

Console.WriteLine("\nAnimals loaded from file:");
DisplayAnimals(animals);

// If no animals were loaded, use default data
if (animals.Count == 0)
{
    animals = new List<Animal>
    {
        new Animal(1, "Luna", 3, "Dog", false),
        new Animal(2, "Max", 5, "Cat", true),
        new Animal(3, "Charlie", 2, "Dog", false),
        new Animal(4, "Bella", 4, "Rabbit", true)
    };
}

// Adding a new animal (for testing)
animals.Add(new Animal(5, "Rocky", 1, "Dog", false));

// Save the updated list back to the file
SaveAnimalsToFile(animals, filePath);

Console.WriteLine("\nAnimals before sorting:");
DisplayAnimals(animals);

// Sort animals by age
animals.Sort((a, b) => a.Age.CompareTo(b.Age));

Console.WriteLine("\nAnimals after sorting by age:");
DisplayAnimals(animals);

// Searching for an animal
Console.Write("\nEnter animal name to search: ");
string searchName = Console.ReadLine();
Animal foundAnimal = SearchAnimalByName(animals, searchName);

if (foundAnimal != null)
{
    Console.WriteLine($"Found: {foundAnimal}");
}
else
{
    Console.WriteLine("Animal not found.");
}

// Methods
void DisplayAnimals(List<Animal> animals)
{
    foreach (var animal in animals)
    {
        Console.WriteLine(animal);
    }
}

Animal SearchAnimalByName(List<Animal> animals, string name)
{
    return animals.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}

void SaveAnimalsToFile(List<Animal> animals, string filePath)
{
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        foreach (var animal in animals)
        {
            writer.WriteLine($"{animal.ID},{animal.Name},{animal.Age},{animal.Species},{animal.AdoptionStatus}");
        }
    }
    Console.WriteLine("\nAnimals saved to file.");
}

List<Animal> LoadAnimalsFromFile(string filePath)
{
    List<Animal> animals = new List<Animal>();

    if (File.Exists(filePath))
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                animals.Add(new Animal(
                    int.Parse(data[0]),
                    data[1],
                    int.Parse(data[2]),
                    data[3],
                    bool.Parse(data[4])
                ));
            }
        }
        Console.WriteLine("\nAnimals loaded from file.");
    }
    else
    {
        Console.WriteLine("\nNo file found. Starting with an empty list.");
    }

    return animals;
}
