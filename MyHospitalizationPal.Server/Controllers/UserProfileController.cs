using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Models;
using MyHospitalizationPal.Server.Services.UserProfile;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserProfileController : Controller
    {
        private IUserProfileService userProfileService = null;
        public UserProfileController(IUserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        [HttpGet]
        [Route("patients/{encounterId}/profile")]
        public IActionResult GetUserProfileDetails(int encounterId)
        {
            try
            {
                var userProfileDetails = userProfileService.GetUserProfileDetails(encounterId);
                return Ok(userProfileDetails);
            }
            catch (Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }


        [HttpPut]
        [Route("patients/{encounterId}/profile")]
        public IActionResult UpdateUserProfile([FromBody]EditableUserProfileDetails editableUserProfileDetails,
            int encounterId)
        {
            try
            {
                var updateUserProfile = userProfileService.UpdateUserProfileDetails(editableUserProfileDetails, 
                    encounterId);

                return Ok(updateUserProfile);
            }
            catch (Exception e)
            {
                return Ok(e.Message.ToString());
            }
        }

        [HttpPut]
        [Route("patients/{encounterId}/profile/picture")]
        public IActionResult UpdateUserProfilePicture(int encounterId, [FromBody] byte[] profilePicture)
        {
            userProfileService.UpdateProfilePicture(encounterId, profilePicture);
            return Ok("Profile pic updated");
        }
    }
}