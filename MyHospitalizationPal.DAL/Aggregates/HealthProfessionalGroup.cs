using MyHospitalizationPal.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class HealthProfessionalGroup
    {
        public String Type { get; set; }
        public IEnumerable<HealthCareProfessional> HealthProfessionalsList { get; set; }

    }
}
