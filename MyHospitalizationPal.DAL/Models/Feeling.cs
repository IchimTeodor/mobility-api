using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class Feeling
    {
        public int Id { get; set; }
        [Required]
        [StringLength(5)]
        public string Value { get; set; }
        [Required]
        [StringLength(25)]
        public string FeelingType { get; set; }
        public int EncounterNoteId { get; set; }

        [ForeignKey("EncounterNoteId")]
        [InverseProperty("Feeling")]
        public EncounterNote EncounterNote { get; set; }
    }
}
