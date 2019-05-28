using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.Server.Services.ScheduledEvents;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class ScheduledEventsController : Controller
    {
        private IScheduledEventService scheduledEventService = null;
        public ScheduledEventsController(IScheduledEventService scheduledEventService)
        {
            this.scheduledEventService = scheduledEventService;
        }

        [HttpGet]
        [Route("encounters/{encounterId:int}/scheduled-events/review")]
        public IActionResult GetScheduledEventsList(int encounterId, int? limit)
        {
            try
            {
                var scheduledEventsList = scheduledEventService.GetScheduledEventsList(encounterId, limit);
                return Ok(scheduledEventsList);
            }catch(Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("encounters/{encounterId:int}/scheduled-events/{scheduledEventId}")]
        public IActionResult GetScheduledEventDetails(int encounterId, int scheduledEventId)
        {
            try
            {
                var scheduledEventDetails = scheduledEventService.GetScheduledEventDetails(encounterId, scheduledEventId);
                return Ok(scheduledEventDetails);
            }catch(Exception e)
            {
                return NotFound(e.Message.ToString());
            }
        }
    }
}