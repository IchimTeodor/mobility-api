using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.UserProfile
{
    public interface IUserProfileService
    {
        UserProfileDetails GetUserProfileDetails(int encounterId);

        UserProfileDetails UpdateUserProfileDetails(EditableUserProfileDetails editableUserProfileDetails, 
            int encounterId);
        void UpdateProfilePicture(int encounterId, byte[] picture);
    }
}
