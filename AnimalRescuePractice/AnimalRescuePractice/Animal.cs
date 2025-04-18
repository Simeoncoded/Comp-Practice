using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescuePractice
{
    class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; } // Example: Dog, Cat, etc.
        public bool AdoptionStatus { get; set; } // true = adopted, false = not adopted

        public Animal(int id, string name, int age, string species, bool adoptionStatus)
        {
            ID = id;
            Name = name;
            Age = age;
            Species = species;
            AdoptionStatus = adoptionStatus;
        }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Age}, {Species}, {AdoptionStatus}";
        }
    }

}
