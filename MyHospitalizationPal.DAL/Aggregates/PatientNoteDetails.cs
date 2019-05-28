using MyHospitalizationPal.DAL.Enums;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class PatientNoteDetails
    {
        public int Id { get; set; }

        public DateTime DateOfDocumentation { get; set; }

        public string FeelingType { get; set; }

        public string Value { get; set; }

        public string Comment { get; set; }
    }
}
