using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class UserAdditional : User
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
