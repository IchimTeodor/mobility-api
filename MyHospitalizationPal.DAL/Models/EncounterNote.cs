using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class EncounterNote
    {
        public EncounterNote()
        {
            Feeling = new HashSet<Feeling>();
        }

        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfDocumentation { get; set; }
        [StringLength(50)]
        public string Comment { get; set; }
        [Column("EncounterID")]
        public int EncounterId { get; set; }

        [ForeignKey("EncounterId")]
        [InverseProperty("EncounterNote")]
        public Encounter Encounter { get; set; }
        [InverseProperty("EncounterNote")]
        public ICollection<Feeling> Feeling { get; set; }
    }
}
