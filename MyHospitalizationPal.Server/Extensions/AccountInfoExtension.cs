using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class AccountInfoExtension
    {
        public static AccountInfoDetails AccountInfo(this Patient patient)
        {
            return new AccountInfoDetails()
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Email = patient.Email,
                Phone = patient.Phone
            };
        }
    }
}
