using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IEmergencyContactRepository
    {
        void Create(EmergencyContact entity);
        void Delete(int id);
        EmergencyContact Details(int id);
        void Edit(EmergencyContact entity);
        IEnumerable<EmergencyContact> GetAll();
        IEnumerable<EmergencyContact> GetEmergencyContactsForOnePatient(int patientId);
    }
}
