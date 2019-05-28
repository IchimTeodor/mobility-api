using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class ScheduledEventDetailsExtension
    {
        public static ScheduledEventDetails FilterScheduledEventDetails(this MyHospitalizationPal.DAL.Models.ScheduledEvent scheduledEvent)
        {
            return new ScheduledEventDetails
            {
                ScheduledDate = scheduledEvent.ScheduledDate,
                Location = scheduledEvent.Location,
                Description = scheduledEvent.Description,
                SpecialNote = scheduledEvent.SpecialNote,
                IsSpecialNoteMandatory = scheduledEvent.IsSpecialNoteMandatory,
                AssignedHealthProfessionalId = scheduledEvent.AssignedHealthProfessionalD,
                EstimatedDuration = (scheduledEvent.EndDate - scheduledEvent.ScheduledDate).Value.Duration().ToString()
            };
        }
    }
}
