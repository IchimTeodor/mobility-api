using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.FeelingsGraphic
{
    public interface IFeelingsGraphicService
    {
        IEnumerable<FeelingsGroup> ListOfFeelingGroup(int encounterId);
    }
}
