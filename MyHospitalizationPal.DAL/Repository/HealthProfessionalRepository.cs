using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Enums;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    public class HealthProfessionalRepository : Repository<HealthProfessional>, IHealthProfessionalRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public HealthProfessionalRepository(ApplicationContext context) : base(context)
        {

        }

        public void Create(HealthProfessional entity)
        {
            Context.HealthProfessional.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var health = Context.HealthProfessional.SingleOrDefault(p => p.Id == id);
            Context.HealthProfessional.Remove(health);
            Context.SaveChanges();
        }

        public HealthProfessional Details(int id)
        {
            var health = Context.HealthProfessional.FirstOrDefault(p => p.Id == id);
            return health;
        }

        public void Edit(HealthProfessional entity)
        {
            Context.HealthProfessional.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<HealthProfessional> GetAll()
        {
            var health = Context.HealthProfessional.ToList();
            return health;
        }

        public IEnumerable<HealthCareProfessional> GetHealthProfessionals(int encounterId, int? limit)
        {
            var healthProfessionals = Context.ScheduledEvent
                .Where(e => e.EncounterId == encounterId)
                .Select(e => e.AssignedHealthProfessionalDNavigation)
                .Distinct();
            if(healthProfessionals == null)
            {
                throw new Exception($"No health professionals found for encounterId {encounterId}");
            }
            var filteredHealthProfessionals = limit.HasValue && healthProfessionals.Count() >= limit.Value
                ? healthProfessionals.Take(limit.Value)
                : healthProfessionals;

            var physicians = filteredHealthProfessionals.Select(h => new HealthCareProfessional
            {
                Id = h.Id,
                Department = h.Department,
                Name = h.Name,
                Photo = h.Photo,
                Title = h.Title,
                Type = h.Type
            }
            ).ToList();

            return physicians;

        }

        public IEnumerable<HealthProfessional> GetHealthProfessionalsByType(int encounterId)
        {
            var healthProfessionals = Context.ScheduledEvent
               .Where(e => e.EncounterId == encounterId)
               .Select(e => e.AssignedHealthProfessionalDNavigation)
               .Distinct();
            if (healthProfessionals == null)
            {
                throw new Exception($"No health professionals found for encounterId {encounterId}");
            }
            return healthProfessionals;
           
        }
    }
}
