using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.Server.Extensions;
using MyHospitalizationPal.Server.Models;

namespace MyHospitalizationPal.Server.Services.ScheduledEvents
{
    public class ScheduledEventService : IScheduledEventService
    {
        public IUnitOfWork unitOfWork = null;
        public ScheduledEventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ScheduledEventDetails GetScheduledEventDetails(int encounterId, int scheduledEventId)
        {
            var scheduledEvent = unitOfWork.ScheduledEventRepository
                .GetScheduledEventDetailsForEncounter(encounterId, scheduledEventId)
                .FilterScheduledEventDetails();
            var healthProfessional = unitOfWork
                .HealthProfessionalRepository.Details(scheduledEvent.AssignedHealthProfessionalId);
            scheduledEvent.AssignedHealthProfessionalName = healthProfessional.Name;
            scheduledEvent.AssignedHealthProfessionalType = healthProfessional.Type;
            return scheduledEvent;
        }

        public IEnumerable<ScheduledEvent> GetScheduledEventsList(int encounterId, int? limit)
        {
            var scheduledEvents = unitOfWork.ScheduledEventRepository
                .GetScheduledEventsListForEncounter(encounterId, limit)
                .Select(e => e.FilterScheduledEvent()).ToList();
            foreach(var scheduledEvent in scheduledEvents)
            {
                var healthProfessional = unitOfWork
                    .HealthProfessionalRepository.Details(scheduledEvent.AssignedHealthProfessionalId);
                scheduledEvent.AssignedHealthProfessionalName = healthProfessional.Name;
                scheduledEvent.AssignedHealthProfessionalType = healthProfessional.Type;
            }
            return scheduledEvents;
        }
    }
}
