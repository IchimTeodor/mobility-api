using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IDailyScheduleRepository : IRepository<DailySchedule>
    {
        void Create(DailySchedule entity);
        void Delete(int id);
        void Edit(DailySchedule entity);
        IEnumerable<DailySchedule> GetAll();
        IEnumerable<DailySchedule> GetDailySchedulesForHealthProfessional(int healthProfessionalId);
    }
}
