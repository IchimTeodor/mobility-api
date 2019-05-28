using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class HealthProfessionalDetailsExtension
    {
        public static HealthProfessionalDetails FilterHealthProfessionalDetails(this MyHospitalizationPal.DAL.Models.HealthProfessional healthProfessional)
        {
            //byte[] photo = null;
            //try
            //{
            //    photo = System.IO.File.ReadAllBytes($@".\ProfilePictures\{healthProfessional.Name}.jpg");
            //}
            //catch (Exception)
            //{

            //}
            return new HealthProfessionalDetails
            {
                Id = healthProfessional.Id,
               // Photo = photo,
                Title = healthProfessional.Title,
                Name = healthProfessional.Name,
                Type = healthProfessional.Type,
                Department = healthProfessional.Department,
                EmergencyPhoneNumber = healthProfessional.EmergencyPhoneNumber,
                ReviewMark = healthProfessional.ReviewMark,
                DailySchedule = null,
                ScheduledEvents = null
            };
        }
    }
}
