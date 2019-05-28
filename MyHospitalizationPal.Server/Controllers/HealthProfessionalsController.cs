using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Services.HealthProfessional;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class HealthProfessionalsController : Controller
    {
        private IHealthProfessionalService healthProfessionalService = null;
        public HealthProfessionalsController(IHealthProfessionalService healthProfessionalService)
        {
            this.healthProfessionalService = healthProfessionalService;
        }
        [HttpGet]
        [Route("encounters/{encounterId:int}/health-professionals/review")]
        public IActionResult HealthProfessionalsList(int encounterId, int? limit)
        {
            try
            {
                var healthProfessionals = healthProfessionalService.GetHealthProfessionalsList(encounterId, limit);
                return Ok(healthProfessionals);
            }
            catch (Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("encounters/{encounterId:int}/health-professionals")]
        public IActionResult HealthProfessionalsByType(int encounterId)
        {
            try
            {
                var healthProfessionalsByType = healthProfessionalService.GetHealthProfessionalsByType(encounterId);
                return Ok(healthProfessionalsByType);
            }
            catch (Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("encounters/{encounterId:int}/health-professionals/{id}")]
        public IActionResult HealthProfessionalById(int encounterId, int id)
        {
            try
            {
                var healthProfessionalDetails = healthProfessionalService.GetHealthProfessionalById(id, encounterId);
                return Ok(healthProfessionalDetails);
            }catch(Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
    }
}