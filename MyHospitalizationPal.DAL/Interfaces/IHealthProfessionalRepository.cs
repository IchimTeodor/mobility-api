using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IHealthProfessionalRepository : IRepository<HealthProfessional>
    {
        void Create(HealthProfessional entity);
        void Delete(int id);
        HealthProfessional Details(int id);
        void Edit(HealthProfessional entity);
        IEnumerable<HealthProfessional> GetAll();
        IEnumerable<HealthCareProfessional> GetHealthProfessionals(int encounterId, int? limit);
        IEnumerable<HealthProfessional> GetHealthProfessionalsByType(int encounterId);
    }
}
