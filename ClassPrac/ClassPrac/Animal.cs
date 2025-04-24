using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPrac
{
    public class Animal
    {
        private string id;

        public string ID {

            get
            {
                return id;
            }


            set
            {
                if (value.Length != 8)
                {
                    Console.WriteLine("ID must be 8 in length");
                }
                else
                {
                    id = value;
                }
            }
        
        }
        public string Species { get; set; }
        public char Gender { get; set; }
        public bool IsSpayed { get; set; }
        public string Breed { get; set; }
        public string Colour { get; set; }
        public DateTime Birthday { get; set; }
        public string VaccineStatus { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public double AdoptionFee { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? AdoptionDate { get; set; } // Nullable if not adopted yet


        // Constructor
        public Animal(string id, string species, char gender, bool isSpayed, string breed, string colour,
                      DateTime birthday, string vaccineStatus, string identificationType, string identificationNumber,
                      double adoptionFee, bool isarchived, DateTime? adoptiondate)
        {
            ID = id;
            Species = species;
            Gender = gender;
            IsSpayed = isSpayed;
            Breed = breed;
            Colour = colour;
            Birthday = birthday;
            VaccineStatus = vaccineStatus;
            IdentificationType = identificationType;
            IdentificationNumber = identificationNumber;
            AdoptionFee = adoptionFee;
            IsArchived = isarchived;
            adoptiondate = AdoptionDate;
        }
    }

}
