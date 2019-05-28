using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class EmergencyContact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column("PatientID")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("EmergencyContact")]
        public Patient Patient { get; set; }
    }
}
