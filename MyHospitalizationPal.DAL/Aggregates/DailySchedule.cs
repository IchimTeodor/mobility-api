using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class DailySchedule
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
