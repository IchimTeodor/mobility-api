using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEncounterRepository EncounterRepository { get; }
        IDailyScheduleRepository DailyScheduleRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmergencyContactRepository EmergencyContactRepository { get; }
        IEncounterNoteRepository EncounterNoteRepository { get; }
        IHealthProfessionalRepository HealthProfessionalRepository { get; }
        IPatientRepository PatientRepository { get; }
        IRoomRepository RoomRepository { get; }
        IScheduledEventRepository ScheduledEventRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }
        IUserBannerDetailsRepository UserBannerDetailsRepository { get; }
        IPatientNoteRepository PatientNoteRepository { get; }
        IFeelingRepository FeelingRepository { get; }
        void Commit();
    }
}
