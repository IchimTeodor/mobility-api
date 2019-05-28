using System;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Repository;
using MyHospitalizationPal.Server.Extensions;
using MyHospitalizationPal.Server.Models;

namespace MyHospitalizationPal.Server.Services.Register
{
    public class RegisterService : IRegisterService
    {
        public IUnitOfWork unitOfWork = null;
        public RegisterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork as UnitOfWork;
        }

        public bool CheckUnicode(string uniqueCodeId)
        {
            var encounter = unitOfWork.EncounterRepository.GetEncounterByUniqueCodeId(uniqueCodeId);
            var userAccount = unitOfWork.UserInfoRepository.GetUserByUnicodeId(uniqueCodeId);
            if(encounter != null && userAccount == null)
            {
                return true;
            }
            return false;
           
        }

        public AccountInfoDetails GetDetails(string uniqueCodeId)
        {
            var encounter = unitOfWork.EncounterRepository.GetEncounterByUniqueCodeId(uniqueCodeId);
            if (encounter == null)
            {
                throw new Exception($"No encounter found for uniqueId {uniqueCodeId}");
            }
            var patient = unitOfWork.PatientRepository.Details(encounter.PatientId);
            if (patient == null)
            {
                throw new Exception($"No patient found for uniqueId {uniqueCodeId} and encounterId {encounter.Id}");
            }
            return patient.AccountInfo();
        }

        public int Register(UserAdditional user)
        {
            var encounter = unitOfWork.EncounterRepository.GetEncounterByUniqueCodeId(user.UniqueCodeId);
            
            if (encounter == null)
            {
                throw new Exception($"No encounter found for uniqueId {user.UniqueCodeId}");
            }
            var userCheck = unitOfWork.UserInfoRepository.GetUserByUnicodeId(user.UniqueCodeId);
            if (userCheck != null)
            {
                throw new Exception($"An account for unicodeId {user.UniqueCodeId} already exists");
            }
            var patientId = encounter.PatientId;
            var patient = unitOfWork.PatientRepository.Details(patientId);
            patient.Email = user.Email;
            patient.Phone = user.Phone;
            unitOfWork.PatientRepository.Edit(patient);
            var userCreated = user.UserInfoDetails(encounter.Id);
            userCreated.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            unitOfWork.UserInfoRepository.Create((userCreated));
            unitOfWork.Commit();

            return encounter.Id;
        }
    }
}
