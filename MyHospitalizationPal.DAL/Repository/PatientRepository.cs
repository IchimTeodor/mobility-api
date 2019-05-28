using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.DAO.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public PatientRepository(ApplicationContext context) : base(context)
        {
            
        }
        public void Create(Patient entity)
        {
            Context.Patient.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var patient = Context.Patient.SingleOrDefault(p => p.Id == id);
            Context.Patient.Remove(patient);
            Context.SaveChanges();
        }

        public Patient Details(int id)
        {
            var patient = Context.Patient.SingleOrDefault(p => p.Id == id);
            return patient;
        }

        public void Edit(Patient entity)
        {
            Context.Patient.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<Patient> GetAll()
        {
            var patients = Context.Patient.ToList();
            return patients;
        }
    }
}
