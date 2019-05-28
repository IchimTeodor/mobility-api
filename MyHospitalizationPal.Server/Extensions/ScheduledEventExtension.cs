using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class ScheduledEventExtension
    {
        public static ScheduledEvent FilterScheduledEvent(this MyHospitalizationPal.DAL.Models.ScheduledEvent scheduledEvent)
        {
            return new ScheduledEvent
            {
                ScheduledEventId = scheduledEvent.Id,
                ScheduledDate = scheduledEvent.ScheduledDate,
                Location = scheduledEvent.Location,
                Description = scheduledEvent.Description,
                SpecialNote = scheduledEvent.SpecialNote,
                IsSpecialNoteMandatory = scheduledEvent.IsSpecialNoteMandatory,
                AssignedHealthProfessionalId = scheduledEvent.AssignedHealthProfessionalD
                
            };
        }
    }
}
