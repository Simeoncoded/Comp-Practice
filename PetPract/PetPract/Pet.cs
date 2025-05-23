﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPract
{
    public class Pet
    {
        public string ID {get; set;}

        public string Name {get; set;}  

        public string Species {get; set;}

        public DateTime CheckInTime { get; set;}

        public bool isCheckedOut { get; set;}


        public Pet (string id, string name, string species, DateTime checkInTime, bool ischeckedout)
        {
            ID = id;
            Name = name;
            Species = species;
            CheckInTime = checkInTime;
            isCheckedOut = ischeckedout;      

        }
    }
}
