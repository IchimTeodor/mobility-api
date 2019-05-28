using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Services.UserBanner;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserBannerDetailsController : Controller
    {
        private IUserBannerService bannerService = null;
        public UserBannerDetailsController(IUserBannerService bannerService)
        {
            this.bannerService = bannerService;
        }

        [HttpGet, Route("banner/{encounterId}")]
        public IActionResult BannerDetails(int encounterId)
        {
            var bannerDetails = bannerService.GetUserBanner(encounterId);
            return Ok(bannerDetails);

        }


    }

}