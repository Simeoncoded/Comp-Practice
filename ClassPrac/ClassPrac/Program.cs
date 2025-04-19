using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPrac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal
            {
                animalID = "00000001",
                species = "Dog",
                gender = 'M',
                isSpayed = true,
                colour = "Brown",
                birthday = new DateTime(2018, 5, 23),
                vaccineStatus = "Up to date",
                IdType = "Micro-chipped",
                IdNo = "MC12345678",
                adoptionFee = 200

            };
        }
    }
}

