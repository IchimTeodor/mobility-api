using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class HealthProfessionalExtension
    {
        public static HealthCareProfessional HealthCareProfessionalDetails(this HealthProfessional healthCareProfessional)
        {
            return new HealthCareProfessional()
            {
                Photo = healthCareProfessional.Photo,
                Department = healthCareProfessional.Department,
                Id = healthCareProfessional.Id,
                Name = healthCareProfessional.Name,
                Title = healthCareProfessional.Title,
                Type = healthCareProfessional.Type
            };
        }
    }
}
