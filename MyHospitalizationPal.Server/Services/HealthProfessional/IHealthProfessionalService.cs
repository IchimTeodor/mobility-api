using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.Server.Models;

namespace MyHospitalizationPal.Server.Services.HealthProfessional
{
    public interface IHealthProfessionalService
    {
        IEnumerable<HealthCareProfessional> GetHealthProfessionalsList(int encounterId, int? limit);
        IEnumerable<HealthProfessionalGroup> GetHealthProfessionalsByType(int encounterId);
        HealthProfessionalDetails GetHealthProfessionalById(int id, int encounterId); 
    }
}
