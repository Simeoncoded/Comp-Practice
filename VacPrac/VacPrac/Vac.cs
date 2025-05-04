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

            set { 
                if(value.Length != 8)
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
    }
}
