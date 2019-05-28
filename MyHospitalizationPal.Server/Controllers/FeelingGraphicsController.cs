using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Services.FeelingsGraphic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api/encounters")]
    [ApiController]
    public class FeelingGraphicsController : Controller
    {
        private IFeelingsGraphicService feelingsGraphicService;

        public FeelingGraphicsController(IFeelingsGraphicService feelingsGraphicService)
        {
            this.feelingsGraphicService = feelingsGraphicService;
        }

        [HttpGet, Route("{encounterId:int}/feelings-graphic")]
        public IActionResult FeelingsGraphicList(int encounterId)
        {
            var feelingDetails = feelingsGraphicService.ListOfFeelingGroup(encounterId);

            return Ok(feelingDetails);
        }

    }
}
