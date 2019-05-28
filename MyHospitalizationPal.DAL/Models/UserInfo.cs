using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UniqueCodeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public int NumberLoginAttempts { get; set; }
        public bool IsActive { get; set; }
        [Column("EncounterID")]
        public int EncounterId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfExpiration { get; set; }

        [ForeignKey("EncounterId")]
        [InverseProperty("UserInfo")]
        public Encounter Encounter { get; set; }
    }
}
