using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class ScheduledEvent
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ScheduledDate { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(10)]
        public string SpecialNote { get; set; }
        public bool IsSpecialNoteMandatory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        public int AssignedHealthProfessionalD { get; set; }
        [Column("EncounterID")]
        public int EncounterId { get; set; }

        [ForeignKey("AssignedHealthProfessionalD")]
        [InverseProperty("ScheduledEvent")]
        public HealthProfessional AssignedHealthProfessionalDNavigation { get; set; }
        [ForeignKey("EncounterId")]
        [InverseProperty("ScheduledEvent")]
        public Encounter Encounter { get; set; }
    }
}
