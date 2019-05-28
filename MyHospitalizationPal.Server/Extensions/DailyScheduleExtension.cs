using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Extensions
{
    public static class DailyScheduleExtension
    {
        public static DailySchedule FilterDailySchedule(this MyHospitalizationPal.DAL.Models.DailySchedule dailySchedule)
        {
            return new DailySchedule
            {
                DayOfWeek = dailySchedule.DayOfWeek,
                StartTime = dailySchedule.StartTime,
                EndTime = dailySchedule.EndTime
            };
        }
    }
}
