using MyHospitalizationPal.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Converter
{
    public class EnumConverter
    {
  
        public static string ConverterFeelingType(FeelingType ft)
        {
            switch (ft)
            {
                case FeelingType.PhysicalCondition:
                    return "Physical Condition";

                case FeelingType.Mood:
                    return "Mood";

                default:
                    throw new Exception("The FeelingType doesn't exist!");
            }

        }


        public static string ConverterValue(Value val)
        {
            switch (val)
            {
                case Value.VeryBad:
                    return "-2";

                case Value.Bad:
                    return "-1";

                case Value.Neutral:
                    return "0";

                case Value.Happy:
                    return "1";

                case Value.VeryHappy:
                    return "2";

                default:
                    throw new Exception("The Value doesn't exist!");
            }

        }
    }
}
