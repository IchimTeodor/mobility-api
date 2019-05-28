using MyHospitalizationPal.DAL.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.UserBanner
{
    public interface IUserBannerService
    {
        UserBannerDetails GetUserBanner(int encounterId);
    }
}
