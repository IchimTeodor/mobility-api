using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    class ScheduledEventRepository : Repository<ScheduledEvent>, IScheduledEventRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public ScheduledEventRepository(ApplicationContext context) : base(context)
        {
            
        }

        public void Create(ScheduledEvent entity)
        {
            Context.ScheduledEvent.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var schedule = Context.ScheduledEvent.SingleOrDefault(p => p.Id == id);
            Context.ScheduledEvent.Remove(schedule);
            Context.SaveChanges();
        }

        public ScheduledEvent Details(int id)
        {
            var schedule = Context.ScheduledEvent.SingleOrDefault(p => p.Id == id);
            return schedule;
        }

        public void Edit(ScheduledEvent entity)
        {
            Context.ScheduledEvent.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<ScheduledEvent> GetAll()
        {
            var schedule = Context.ScheduledEvent.ToList();
            return schedule;
        }
        public IEnumerable<ScheduledEvent> GetScheduledEventsForHealthProfessional(int healthProfessionalId, int encounterId)
        {
            return Context.ScheduledEvent.Where(s => s.AssignedHealthProfessionalD == healthProfessionalId && s.EncounterId == encounterId).ToList(); //&& s.ScheduledDate >= DateTime.Today)
        }
        public IEnumerable<ScheduledEvent> GetScheduledEventsListForEncounter(int encounterId, int? limit)
        {
            var scheduledEvents = Context.ScheduledEvent.Where(e => e.EncounterId == encounterId);
            if(scheduledEvents == null)
            {
                throw new Exception($"No scheduled events found for encounterId {encounterId}");
            }
            return limit.HasValue && scheduledEvents.Count() >= limit.Value
                ? scheduledEvents.Take(limit.Value).ToList()
                : scheduledEvents.ToList();
        }
        public ScheduledEvent GetScheduledEventDetailsForEncounter(int encounterId, int scheduledEventId)
        {
            var scheduledEvent = Context.ScheduledEvent.FirstOrDefault(e => e.EncounterId == encounterId && e.Id == scheduledEventId);
            if(scheduledEvent == null)
            {
                throw new Exception($"No scheduled event found for ecounterId {encounterId} and scheduledEventId {scheduledEventId}");
            }
            return scheduledEvent;
        }
    }
}
