using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Aggregates
{
    public static class FeelingExtension
    {
        public static Feeling Feelings(FeelingMode feelingMode)
        {
            return new Feeling
            {
                FeelingType = feelingMode.FeelingType,
                Value = feelingMode.Value
            };
        }
    }
}
