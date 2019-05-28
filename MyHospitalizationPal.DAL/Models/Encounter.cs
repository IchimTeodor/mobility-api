using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class Encounter
    {
        public Encounter()
        {
            EncounterNote = new HashSet<EncounterNote>();
            ScheduledEvent = new HashSet<ScheduledEvent>();
            UserInfo = new HashSet<UserInfo>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int RoomId { get; set; }
        [StringLength(50)]
        public string Details { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfHospitalization { get; set; }
        [Column("PatientID")]
        public int PatientId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfDischarge { get; set; }
        [Required]
        [StringLength(50)]
        public string BraceletTagId { get; set; }

        [ForeignKey("DepartmentId")]
        [InverseProperty("Encounter")]
        public Department Department { get; set; }
        [ForeignKey("PatientId")]
        [InverseProperty("Encounter")]
        public Patient Patient { get; set; }
        [ForeignKey("RoomId")]
        [InverseProperty("Encounter")]
        public Room Room { get; set; }
        [InverseProperty("Encounter")]
        public ICollection<EncounterNote> EncounterNote { get; set; }
        [InverseProperty("Encounter")]
        public ICollection<ScheduledEvent> ScheduledEvent { get; set; }
        [InverseProperty("Encounter")]
        public ICollection<UserInfo> UserInfo { get; set; }
    }
}
