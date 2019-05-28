using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class EncounterDetailsExtension
    {
        public static EncounterDetails FilterEncounterDetails(this Encounter encounter, string department, int room)
        {
            return new EncounterDetails
            {
                DateOfHospitalization = encounter.DateOfHospitalization,
                Department = department,
                Room = room
            };
        }

    }
}
