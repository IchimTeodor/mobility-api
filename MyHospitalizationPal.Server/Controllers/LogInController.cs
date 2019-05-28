using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Models;
using MyHospitalizationPal.Server.Services.Login;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LogInController : Controller
    {
        private ILoginService loginService;

        public LogInController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]User user)
        {

            var encounterId = loginService.Login(user);

            return Ok(new EncounterIdResponse
            {
                EncounterId = encounterId
            });

        }
    }
}