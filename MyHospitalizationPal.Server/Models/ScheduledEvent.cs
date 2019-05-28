using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class ScheduledEvent
    {
        public int ScheduledEventId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string SpecialNote { get; set; }
        public bool IsSpecialNoteMandatory { get; set; }
        public int AssignedHealthProfessionalId { get; set; }
        public string AssignedHealthProfessionalType { get; set; }
        public string AssignedHealthProfessionalName { get; set; }

    }
}
