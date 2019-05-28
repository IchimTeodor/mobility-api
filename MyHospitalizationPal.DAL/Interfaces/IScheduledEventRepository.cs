using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IScheduledEventRepository :IRepository<ScheduledEvent>
    {
        void Create(ScheduledEvent entity);
        void Delete(int id);
        ScheduledEvent Details(int id);
        void Edit(ScheduledEvent entity);
        IEnumerable<ScheduledEvent> GetAll();
        IEnumerable<ScheduledEvent> GetScheduledEventsForHealthProfessional(int healthProfessionalId, int encounterId);
        IEnumerable<ScheduledEvent> GetScheduledEventsListForEncounter(int encounterId, int? limit);
        ScheduledEvent GetScheduledEventDetailsForEncounter(int encounterId, int scheduledEventId);
    }
}
