using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Enums;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.Converter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class PatientNoteExtension
    {
        public static Feeling PatientNotes(this Feeling feeling, PatientNoteAdd patientNoteAdd)
        {
            return new Feeling
            {
            };
        }
    }
}
