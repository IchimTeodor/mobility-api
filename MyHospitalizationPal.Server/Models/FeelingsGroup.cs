using MyHospitalizationPal.DAL.Enums;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Models
{
    public class FeelingsGroup
    {
        public string GroupType;

        public List<FeelingModel> FeelinngList;
    }
}
