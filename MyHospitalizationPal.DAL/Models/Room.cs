using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHospitalizationPal.DAL.Models
{
    public partial class Room
    {
        public Room()
        {
            Encounter = new HashSet<Encounter>();
        }

        public int Id { get; set; }
        public int RoomNumber { get; set; }

        [InverseProperty("Room")]
        public ICollection<Encounter> Encounter { get; set; }
    }
}
