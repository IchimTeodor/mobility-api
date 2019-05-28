using MyHospitalizationPal.DAL.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IUserBannerDetailsRepository
    {
       UserBannerDetails DetailsForBanner(int EncounterId);
    }
}
