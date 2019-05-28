using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class PatientNoteAdd
    {
        public int EncounterId { get; set; }

        public DateTime DateOfDocumentation { get; set; }

        public IEnumerable<FeelingModeEnum> FeelingMode { get; set; }

        public string Comment { get; set; }
    }
}
