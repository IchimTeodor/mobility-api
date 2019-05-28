using Microsoft.EntityFrameworkCore;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.DAO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext dbContext { get; }
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        // Repositories.
        public IEncounterRepository EncounterRepository => new EncounterRepository(dbContext);
        public IDailyScheduleRepository DailyScheduleRepository => new DailyScheduleRepository(dbContext);
        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(dbContext);
        public IEmergencyContactRepository EmergencyContactRepository => new EmergencyContactRepository(dbContext);
        public IEncounterNoteRepository EncounterNoteRepository => new EncounterNoteRepository(dbContext);
        public IHealthProfessionalRepository HealthProfessionalRepository => new HealthProfessionalRepository(dbContext);
        public IPatientRepository PatientRepository => new PatientRepository(dbContext);
        public IRoomRepository RoomRepository => new RoomRepository(dbContext);
        public IScheduledEventRepository ScheduledEventRepository => new ScheduledEventRepository(dbContext);
        public IUserInfoRepository UserInfoRepository => new UserInfoRepository(dbContext);
        public IUserBannerDetailsRepository UserBannerDetailsRepository => new UserBannerDetailsRepository(dbContext);
        public IPatientNoteRepository PatientNoteRepository => new PatientNoteRepository(dbContext);
        public IFeelingRepository FeelingRepository => new FeelingRepository(dbContext);



        public UnitOfWork(ApplicationContext applicationContext)
        {
            dbContext = applicationContext;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repository = new Repository<T>(dbContext);
            repositories.Add(typeof(T), repository);
            return repository;
        }

        public UnitOfWork(DbContext context)
        {
            dbContext = context as ApplicationContext;
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
