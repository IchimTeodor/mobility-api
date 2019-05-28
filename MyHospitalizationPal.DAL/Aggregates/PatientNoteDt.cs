using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class PatientNoteDt
    {
        public int Id { get; set; }

        public DateTime DateOfDocumentation { get; set; }

        public IEnumerable<FeelingMode> FeelingMode { get; set; }

        public string Comment { get; set; }
    }
}
