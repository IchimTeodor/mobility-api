using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class DailySchedule
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string StartTime { get; set; }
        [Required]
        [StringLength(20)]
        public string EndTime { get; set; }
        [Required]
        [StringLength(20)]
        public string DayOfWeek { get; set; }
        public int HeathProfessionalId { get; set; }

        [ForeignKey("HeathProfessionalId")]
        [InverseProperty("DailySchedule")]
        public HealthProfessional HeathProfessional { get; set; }
    }
}
