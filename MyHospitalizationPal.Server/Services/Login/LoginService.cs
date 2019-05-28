using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Repository;
using MyHospitalizationPal.Server.Models;
using System;

namespace MyHospitalizationPal.Server.Services.Login
{
    public class LoginService : ILoginService
    {
        public IUnitOfWork unitOfWork = null;

        public LoginService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork as UnitOfWork;
        }


        public int Login(User user)
        {
            var userlog = unitOfWork.UserInfoRepository.GetUserByUnicodeId(user.UniqueCodeId);
            if (userlog == null)
            {
                throw new Exception($"No encounter found for uniqueId {user.UniqueCodeId}");
            }
            if (!userlog.IsActive)
            {
                throw new Exception($"Account inactive for {user.UniqueCodeId}");
            }
            if (userlog.NumberLoginAttempts >= 3)
            {
                //userlog.IsActive = false;
                //unitOfWork.UserInfoRepository.Update(userlog);
                //unitOfWork.Commit();
                throw new Exception($"Account locked");
            }
            
            if (!BCrypt.Net.BCrypt.Verify(user.Password, userlog.Password))
            {
                userlog.NumberLoginAttempts++;
                if (userlog.NumberLoginAttempts == 3)
                {
                    userlog.IsActive = false;
                }
                unitOfWork.UserInfoRepository.Edit(userlog);
                unitOfWork.Commit();
                throw new Exception($"Wrong credentials");
            }

            userlog.NumberLoginAttempts = 0;
            unitOfWork.UserInfoRepository.Edit(userlog);
            unitOfWork.Commit();

            return userlog.EncounterId;
        }
    }
}
