using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class HealthProfessional
    {
        public HealthProfessional()
        {
            DailySchedule = new HashSet<DailySchedule>();
            ScheduledEvent = new HashSet<ScheduledEvent>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Photo { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Required]
        [StringLength(10)]
        public string Type { get; set; }
        [Required]
        [StringLength(15)]
        public string EmergencyPhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string ReviewMark { get; set; }

        [InverseProperty("HeathProfessional")]
        public ICollection<DailySchedule> DailySchedule { get; set; }
        [InverseProperty("AssignedHealthProfessionalDNavigation")]
        public ICollection<ScheduledEvent> ScheduledEvent { get; set; }
    }
}
