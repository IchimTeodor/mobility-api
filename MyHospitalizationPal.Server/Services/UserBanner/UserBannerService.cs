using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Repository;

namespace MyHospitalizationPal.Server.Services.UserBanner
{
    public class UserBannerService : IUserBannerService
    {
        public IUnitOfWork unitOfWork = null;
        public UserBannerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork as UnitOfWork;
        }
        public UserBannerDetails GetUserBanner(int encounterId)
        {
            var bannerDetails = unitOfWork.UserBannerDetailsRepository.DetailsForBanner(encounterId);
            return bannerDetails; 
        }
    }
}
