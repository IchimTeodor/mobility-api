using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    class EmergencyContactRepository : Repository<EmergencyContact>, IEmergencyContactRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        

        public EmergencyContactRepository(ApplicationContext context) : base(context)
        {
            
        }

        public void Create(EmergencyContact entity)
        {
            Context.EmergencyContact.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var emergencyContact = Context.EmergencyContact.SingleOrDefault(c => c.Id == id);
            Context.EmergencyContact.Remove(emergencyContact);
            Context.SaveChanges();
        }

        public EmergencyContact Details(int id)
        {
            return Context.EmergencyContact.SingleOrDefault(c => c.Id == id);
        }

        public void Edit(EmergencyContact entity)
        {
            Context.EmergencyContact.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<EmergencyContact> GetAll()
        {
            return Context.EmergencyContact.ToList();
        }
        public IEnumerable<EmergencyContact> GetEmergencyContactsForOnePatient(int patientId)
        {
            var emergencyContacts = Context.EmergencyContact.Where(c => c.PatientId == patientId).ToList();
            if(emergencyContacts == null)
            {
                throw new Exception($"No emergency contacts found for patientId {patientId}");
            }
            return emergencyContacts;
        }
    }
}
