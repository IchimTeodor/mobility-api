using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Enums;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.Server.Extensions;
using MyHospitalizationPal.Server.Models;

namespace MyHospitalizationPal.Server.Services.HealthProfessional
{
    public class HealthProfessionalService : IHealthProfessionalService
    {
        public IUnitOfWork unitOfWork = null;
        private readonly IOptions<AppSettings> appSettings;
        public HealthProfessionalService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this.unitOfWork = unitOfWork;
            this.appSettings = appSettings;
        }

        public IEnumerable<HealthCareProfessional> GetHealthProfessionalsList(int encounterId, int? limit)
        {
            var healthProfessionals = unitOfWork.HealthProfessionalRepository.GetHealthProfessionals(encounterId, limit);
            return healthProfessionals;
        }
        public IEnumerable<HealthProfessionalGroup> GetHealthProfessionalsByType(int encounterId)
        {
            var healthProfessionals = unitOfWork.HealthProfessionalRepository.GetHealthProfessionalsByType(encounterId);
            var doctors = healthProfessionals
                .Where(d => d.Type == HealthProfessionalType.Doctor.ToString())
                .Select(e => e.HealthCareProfessionalDetails()).ToList();
            var nurses = healthProfessionals
                .Where(d => d.Type == HealthProfessionalType.Nurse.ToString())
                .Select(e => e.HealthCareProfessionalDetails()).ToList();
            return new List<HealthProfessionalGroup>()
            {
                new HealthProfessionalGroup()
                {
                    Type = HealthProfessionalType.Doctor.ToString(),
                    HealthProfessionalsList = doctors
                },
                new HealthProfessionalGroup()
                {
                    Type = HealthProfessionalType.Nurse.ToString(),
                    HealthProfessionalsList = nurses
                }
            };

        }

        public HealthProfessionalDetails GetHealthProfessionalById(int healthProfessionalId, int encounterId)
        {
            var healthProfessional = unitOfWork.HealthProfessionalRepository.Details(healthProfessionalId);
            var dailySchedule = unitOfWork.DailyScheduleRepository.GetDailySchedulesForHealthProfessional(healthProfessionalId);
            var scheduledEvents = unitOfWork.ScheduledEventRepository.GetScheduledEventsForHealthProfessional(healthProfessionalId, encounterId);

            var filteredHealthProfessional = healthProfessional.FilterHealthProfessionalDetails();
            byte[] photo = null;
            try
            {
                photo = System.IO.File.ReadAllBytes($"{appSettings.Value.PicturePath}/{healthProfessional.Name}.jpg");
            }
            catch (Exception)
            {

            }
            filteredHealthProfessional.Photo = photo;
            filteredHealthProfessional.ScheduledEvents = scheduledEvents.Select(e => e.FilterScheduledEvent()).ToList();
            foreach (var scheduledEvent in filteredHealthProfessional.ScheduledEvents)
            {
                scheduledEvent.AssignedHealthProfessionalName = healthProfessional.Name;
                scheduledEvent.AssignedHealthProfessionalType = healthProfessional.Type;

            }
            filteredHealthProfessional.DailySchedule = dailySchedule.Select(s => s.FilterDailySchedule()).ToList();

            return filteredHealthProfessional;
        }
    }
}
