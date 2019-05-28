using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class EmergencyContactExtension
    {
        public static EmergencyContact FilterEmergencyContact(this MyHospitalizationPal.DAL.Models.EmergencyContact emergencyContact)
        {
            return new EmergencyContact
            {
                Id = emergencyContact.Id,
                Name = emergencyContact.Name,
                Email = emergencyContact.Email,
                Phone = emergencyContact.Phone
            };
        }
    }
}
