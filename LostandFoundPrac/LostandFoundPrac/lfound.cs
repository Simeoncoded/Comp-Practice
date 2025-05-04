using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostandFoundPrac
{
    public enum Status
    {
        lost,
        found
    }
    public class lfound
    {
        public string id {  get; set; }

        public string namae {  get; set; }

        public string species {  get; set; }
        public Status status { get; set; }

        public DateTime reporttime { get; set; }

        public bool isArchived { get; set; }


        public lfound(string id, string namae, string species, Status status, DateTime reporttime)
        {
            this.id = id;
            this.namae = namae;
            this.species = species;
            this.status = status;
            this.reporttime = reporttime;
        }

        public lfound(string id, string namae, string species, Status status, DateTime reporttime, bool isarchived)
        {
            this.id = id;
            this.namae = namae;
            this.species = species;
            this.status = status;
            this.reporttime = reporttime;
            this.isArchived = isarchived;   
        }
    }
}
