using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class FeelingModel
    {
        public string Value { get; set; }
        public EncounterNoteModelForFeelingModel EncounterNote { get; set; }
    }
}
