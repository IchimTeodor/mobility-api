using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.DAL.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    public class UserBannerDetailsRepository : Repository<UserBannerDetails>, IUserBannerDetailsRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }

        public UserBannerDetailsRepository(ApplicationContext context) : base(context)
        {

        }



        public UserBannerDetails DetailsForBanner(int encounterId)
        {

            var encounter = Context.Encounter.SingleOrDefault(e => e.Id == encounterId);
            if (encounter == null)
                throw new Exception($"Encounter with id {encounterId} not found!");

            var patient = Context.Patient.SingleOrDefault(p => p.Id == encounter.PatientId);
            if (patient == null)
                throw new Exception($"Patient with id {encounter.PatientId} not found!");

            var departmentName = Context.Department.SingleOrDefault(d => d.Id == encounter.DepartmentId).DepartmentName;
            var roomNumber = Context.Room.SingleOrDefault(r => r.Id == encounter.RoomId).RoomNumber;


            return new UserBannerDetails
            {
                DepartmentName = departmentName,
                PatientId = patient.Id,
                EncounterId = encounter.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                RoomNr = roomNumber

            };
            
        }

    }
}
