﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPract
{
   public enum Vaccination
    {
        UptoDate,
        Late,
        Unknown
    }

    public enum Status
    {
        Available,
        Adopted,
        Archived
    }
    public class Final
    {
        private string id;

        public string Id { get { return id; }
            set
            {
                if(value.Length != 8)
                {
                    throw new ArgumentException("ID must be exactly 8");
                }
                else
                {
                    id = value;
                }
            }
        }

        public string Species { get; set; }

        public char Gender { get; set; }

        public bool IsInjured {  get; set; } = false;

        public string Breed {  get; set; }

        public string Color {  get; set; }

        public DateTime DOB {  get; set; }

        public DateTime ArrivalDate { get; set; }

        public string Identification {  get; set; }

        public Vaccination Vaccination { get; set; }

        public Status Status { get; set; }

        public bool IsSpayedOrNeutered { get; set; }


        public double AdoptionFee
        {
            get
            {
                var age = DateTime.Now.Year - DOB.Year;
                if (DOB.Date > DateTime.Now.AddYears(-age)) age--;

                if (age < 1) return 300;
                else if (age > 10) return 100;
                else return 200;
            }
        }

        public bool isArchived {  get; set; }

        public Final(string id, string species, char gender, bool isinjured, string breed, string color, DateTime DOB, DateTime ArrivalDate,
                    string identification, Vaccination vaccination, Status status, bool isspayedorneutered)
        {
            this.id = id;
            this.Species = species;
            this.Gender = gender;
            this.IsInjured = isinjured;
            this.Breed = breed;
            this.Color = color;
            this.DOB = DOB;
            this.ArrivalDate= ArrivalDate;
            this.Identification = identification;
            this.Vaccination = vaccination;
            this.Status = status;
            this.IsSpayedOrNeutered = isspayedorneutered;
        }


        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Species: {Species}\n" +
                   $"Gender: {Gender}\n" +
                   $"Spayed/Neutered: {(IsSpayedOrNeutered ? "Yes" : "No")}\n" +
                   $"Breed: {Breed}\n" +
                   $"Color: {Color}\n" +
                   $"DOB: {DOB:yyyy-MM-dd}\n" +
                   $"Arrival: {ArrivalDate:yyyy-MM-dd}\n" +
                   $"Vaccination: {Vaccination}\n" +
                   $"Injured: {(IsInjured ? "Yes" : "No")}\n" +
                   $"Identification: {Identification}\n" +
                   $"Status: {Status}\n" +
                   $"Adoption Fee: ${AdoptionFee}\n";
        }



    }
}
