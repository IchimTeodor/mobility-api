using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class UserProfileDetailsExtension
    {
        public static UserProfileDetails FilterUserProfileDetails(this Patient userProfileDetails)
        {
            return new UserProfileDetails
            {
                //ProfilePicture = userProfileDetails.ProfilePicturePath,
                FirstName = userProfileDetails.FirstName,
                LastName = userProfileDetails.LastName,
                DateOfBirth = userProfileDetails.DateOfBirth,
                BloodType = userProfileDetails.BloodType,
                IsEnsured = userProfileDetails.IsInsured,
                Email = userProfileDetails.Email,
                Phone = userProfileDetails.Phone,
                Address = userProfileDetails.Address,
                Gender = userProfileDetails.Gender
            };
        }
    }
}
