using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class DailySchedule
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
