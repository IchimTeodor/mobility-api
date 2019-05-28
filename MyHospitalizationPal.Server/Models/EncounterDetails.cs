using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class EncounterDetails
    {
        public DateTime DateOfHospitalization { get; set; }
        public string Department { get; set; }
        public int Room { get; set; }
    }
}
