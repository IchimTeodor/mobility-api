using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class ScheduledEventDetails : ScheduledEvent
    {
        
        public string EstimatedDuration { get; set; }

    }
}
