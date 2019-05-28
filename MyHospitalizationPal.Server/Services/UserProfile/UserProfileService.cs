using Microsoft.Extensions.Options;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.Server.Extensions;
using MyHospitalizationPal.Server.Models;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        private IUnitOfWork unitOfWork = null;
        private readonly IOptions<AppSettings> appSettings;
        public UserProfileService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.appSettings = appSettings;
        }

        public UserProfileDetails GetUserProfileDetails(int encounterId)
        {
            var encounter = unitOfWork.EncounterRepository.Details(encounterId);
            var patientDetails = unitOfWork.PatientRepository.Details(encounter.PatientId);
            var emergencyContact = unitOfWork.EmergencyContactRepository.GetEmergencyContactsForOnePatient(patientDetails.Id);

            var department = unitOfWork.DepartmentRepository.Details(encounter.DepartmentId).DepartmentName;
            var room = unitOfWork.RoomRepository.Details(encounter.RoomId).RoomNumber;

            var filteredUserProfileDetails = patientDetails.FilterUserProfileDetails();
            var filteredEncounter = encounter.FilterEncounterDetails(department, room);
            
            filteredUserProfileDetails.EncounterDetails = filteredEncounter;
            filteredUserProfileDetails.EmergencyContact = emergencyContact.Select(c => c.FilterEmergencyContact()).ToList();

            try
            {
                filteredUserProfileDetails.ProfilePicture = System.IO.File.ReadAllBytes($"{appSettings.Value.PicturePath}/{encounter.BraceletTagId}.jpg");
            }
            catch (Exception)
            {
            
            }
           

            return filteredUserProfileDetails;
        }
        public void UpdateProfilePicture(int encounterId, byte[] picture)
        {
            var patient = unitOfWork.PatientRepository.Details(unitOfWork.EncounterRepository.Details(encounterId).PatientId);
            var unicode = unitOfWork.EncounterRepository.Details(encounterId).BraceletTagId;
            

            var image = Image.Load(picture);
            image.Save($"{appSettings.Value.PicturePath}/{unicode}.jpg");

            patient.ProfilePicturePath = $"/{unicode}.txt";
            
            unitOfWork.PatientRepository.Edit(patient);
            unitOfWork.Commit();
            
        }

        public UserProfileDetails UpdateUserProfileDetails(EditableUserProfileDetails editableUserProfileDetails, 
            int encounterId)
        {
            var encounter = unitOfWork.EncounterRepository.Details(encounterId);
            var patientDetails = unitOfWork.PatientRepository.Details(encounter.PatientId);
            var emergencyContact = unitOfWork.EmergencyContactRepository.GetEmergencyContactsForOnePatient(patientDetails.Id);

            var department = unitOfWork.DepartmentRepository.Details(encounter.DepartmentId).DepartmentName;
            var room = unitOfWork.RoomRepository.Details(encounter.RoomId).RoomNumber;

            var filteredUserProfileDetails = patientDetails.FilterUserProfileDetails();

            patientDetails.Email = editableUserProfileDetails.Email;
            patientDetails.Phone = editableUserProfileDetails.Phone;
            patientDetails.Address = editableUserProfileDetails.Address;

            var filteredEncounter = encounter.FilterEncounterDetails(department, room);
            filteredUserProfileDetails.EncounterDetails = filteredEncounter;


            filteredUserProfileDetails.EmergencyContact = new List<EmergencyContact>();

            editableUserProfileDetails
                .EmergencyContact
                .ToList()
                .ForEach(body =>
                {
                    var databaseObject = unitOfWork.EmergencyContactRepository.Details(body.Id);

                    databaseObject.Name = body.Name;
                    databaseObject.Email = body.Email;
                    databaseObject.Phone = body.Phone;

                    filteredUserProfileDetails.EmergencyContact.Add(body);
                });

            unitOfWork.PatientRepository.Edit(patientDetails);
            unitOfWork.Commit();
            
            return GetUserProfileDetails(encounterId);

        }


    }

}
