using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacPrac
{
    public class Vac
    {
        private string id;

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                if (value.Length != 8)
                {
                    throw new Exception("ID shouldnt be more than 8 in length");
                }
                else
                {
                    id = value;
                }

            }
        }

        public string Name { get; set; }

        public string Species { get; set; }

        public bool isVaccinated { get; set; }

        private DateTime valdate { get; set; }

        public DateTime ValDate
        {
            get
            {
                return valdate;
            }

            set
            {
                if (!isVaccinated)
                {
                    valdate = DateTime.MinValue;
                }
                else
                {
                    valdate = value;
                }
            }
        }


        public Vac(string id, string name, string species, bool isVaccinated, DateTime valdate)
        {
            this.id = id;
            this.Name = name;
            this.Species = species;
            this.isVaccinated = isVaccinated;
            this.valdate = valdate;
        }
    }
}