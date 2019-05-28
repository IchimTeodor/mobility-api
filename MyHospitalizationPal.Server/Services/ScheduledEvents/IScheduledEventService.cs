using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.ScheduledEvents
{
    public interface IScheduledEventService
    {
        IEnumerable<ScheduledEvent> GetScheduledEventsList(int encounterId, int? limit);
        ScheduledEventDetails GetScheduledEventDetails(int encounterId, int scheduledEventId);
    }
}
