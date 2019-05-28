using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Models;
using MyHospitalizationPal.Server.Services.Register;
using System;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : Controller
    {
        private IRegisterService registerService;

        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        [HttpGet, Route("patients/checkunicode/{uniqueCodeId}")]
        public IActionResult CheckUnicode(string uniqueCodeId)
        {
            if(registerService.CheckUnicode(uniqueCodeId) == true)
            {
                return Ok();
            }
            return NotFound($"Cannot create an account for {uniqueCodeId}");
        }
        [HttpGet, Route("patients/{uniqueCodeId:int}")]
        public IActionResult Details(string uniqueCodeId)
        {
            var accountInfo = registerService.GetDetails(uniqueCodeId);
            return Ok(accountInfo);
        }

        [HttpPost]
        [Route("patients")]
        public IActionResult Register([FromBody]UserAdditional user)
        {
            try
            {
                var encounterId = registerService.Register(user);
                return Ok(new EncounterIdResponse
                {
                    EncounterId = encounterId
                });
            }
            catch(Exception e)
            {
                return Ok(e.Message.ToString());
            }
        }
    }
}