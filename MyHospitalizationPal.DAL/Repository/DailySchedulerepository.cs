using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    class DailyScheduleRepository : Repository<DailySchedule>, IDailyScheduleRepository
    {
        public ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }

        public DailyScheduleRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(DailySchedule entity)
        {
            Context.DailySchedule.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dailySchedule = Context.DailySchedule.SingleOrDefault(s => s.Id == id);
            Context.DailySchedule.Remove(dailySchedule);
            Context.SaveChanges();
        }

        public DailySchedule Details(int id)
        {
            return Context.DailySchedule.SingleOrDefault(s => s.Id == id);
        }

        public void Edit(DailySchedule entity)
        {
            Context.DailySchedule.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<DailySchedule> GetAll()
        {
            return Context.DailySchedule.ToList();
        }
        public IEnumerable<DailySchedule> GetDailySchedulesForHealthProfessional(int healthProfessionalId)
        {
            return Context.DailySchedule.Where(s => s.HeathProfessionalId == healthProfessionalId).ToList();
        }
    }
}
