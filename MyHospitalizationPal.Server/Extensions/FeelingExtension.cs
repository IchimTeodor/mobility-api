using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Enums;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.Converter;
using System.Collections.Generic;
using System.Linq;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class FeelingExtension
    {
        public static EncounterNote AddNewNote(this PatientNoteAdd patientNotAdd)
        {
            return new EncounterNote
            {
                Comment = patientNotAdd.Comment,
                DateOfDocumentation = patientNotAdd.DateOfDocumentation,
                EncounterId = patientNotAdd.EncounterId,
                Feeling = patientNotAdd.FeelingMode.Select(s => new Feeling
                {
                    FeelingType = EnumConverter.ConverterFeelingType(s.FeelingType),
                    Value = EnumConverter.ConverterValue(s.Value).ToString()
                }
                ).ToList()
            };
        }



    }
}
