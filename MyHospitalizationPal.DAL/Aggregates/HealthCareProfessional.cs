using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class HealthCareProfessional
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }

    }
}
