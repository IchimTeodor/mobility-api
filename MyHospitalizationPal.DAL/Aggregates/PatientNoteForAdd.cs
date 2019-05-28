using MyHospitalizationPal.DAL.Enums;
using System;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class PatientNoteForAdd
    {
        public int EncounterId { get; set; }

        public DateTime DateOfDocumentation { get; set; }

        public FeelingType FeelingType { get; set; }

        public Value Value { get; set; }

        public string Comment { get; set; }
    }
}
