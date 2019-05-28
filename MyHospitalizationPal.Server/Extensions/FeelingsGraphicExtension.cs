using MyHospitalizationPal.DAL.Enums;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.Converter;
using MyHospitalizationPal.Server.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class FeelingsGraphicExtension
    {
        public static FeelingsGroup FeelingsGroupExtension(this IGrouping<string, Feeling> feeling)
        {
            return new FeelingsGroup
            {
                GroupType = feeling.Key,
                FeelinngList = feeling.ToList().Select(f =>
                   {
                       return new FeelingModel
                       {
                           EncounterNote = new EncounterNoteModelForFeelingModel
                           {
                               Comment = f.EncounterNote.Comment,
                               DateOfDocumentation = f.EncounterNote.DateOfDocumentation
                           },
                           Value = f.Value
                       };
                   }).ToList()
            };
        }
    }
}
