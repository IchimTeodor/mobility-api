using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class EditableUserProfileDetails
    {
        public IEnumerable<EmergencyContact> EmergencyContact;

        public string Email;

        public string Phone;

        public string Address;
    }
}
