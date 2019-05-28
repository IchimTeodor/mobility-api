using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class Patient
    {
        public Patient()
        {
            EmergencyContact = new HashSet<EmergencyContact>();
            Encounter = new HashSet<Encounter>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(50)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(5)]
        public string BloodType { get; set; }
        public bool IsInsured { get; set; }
        [StringLength(100)]
        public string ProfilePicturePath { get; set; }

        [InverseProperty("Patient")]
        public ICollection<EmergencyContact> EmergencyContact { get; set; }
        [InverseProperty("Patient")]
        public ICollection<Encounter> Encounter { get; set; }
    }
}
