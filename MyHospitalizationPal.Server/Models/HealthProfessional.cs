using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class HealthProfessional
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }
    }
}
