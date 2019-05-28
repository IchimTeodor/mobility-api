using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class UserProfileDetails
    {
        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public bool IsEnsured { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public EncounterDetails EncounterDetails { get; set; }
        public ICollection<EmergencyContact> EmergencyContact { get; set; }
        public string Gender { get; internal set; }
    }
}
