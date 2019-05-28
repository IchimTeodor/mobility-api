using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class HealthProfessionalDetails : HealthProfessional
    {
        public List<ScheduledEvent> ScheduledEvents { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string ReviewMark { get; set; }
        public List<DailySchedule> DailySchedule { get; set; }
    }
}
