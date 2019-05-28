using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Create(Patient entity);
        Patient Details(int patientId);
        void Delete(int id);
        void Edit(Patient entity);
        IEnumerable<Patient> GetAll();
    }
}
