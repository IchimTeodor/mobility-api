using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class UserExtension
    {

        public static UserInfo UserInfoDetails(this User user, int encounterId)
        {
            return new UserInfo()
            {
                UniqueCodeId = user.UniqueCodeId,
                //Password = user.Password,
                IsActive = true,
                NumberLoginAttempts = 0,
                EncounterId = encounterId,
                DateOfExpiration = DateTime.Now.AddYears(1)
            };
        }
    }
}
