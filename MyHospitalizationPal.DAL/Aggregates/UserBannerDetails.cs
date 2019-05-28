using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public class UserBannerDetails
    {
        public int PatientId { get; set; }

        public int EncounterId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DepartmentName { get; set; }

        public int RoomNr { get; set; }
    }
}
