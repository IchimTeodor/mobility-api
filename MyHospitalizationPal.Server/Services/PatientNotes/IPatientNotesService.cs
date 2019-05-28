using MyHospitalizationPal.DAL.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.PatientNotes
{
    public interface IPatientNotesService
    {
        IEnumerable<PatientNoteDt> GetNotes(int encounterId, int? limit);

        IEnumerable<PatientNoteDt> GetAllNotes(int encounterId);

        PatientNoteDt GetNoteById(int encounterId, int id);

        PatientNoteDt AddNotes(PatientNoteAdd patientNoteForAdd);

        void UpdatePatientNoteById(PatientNoteDt patientNoteDetails, int encounterId, int id);

        void DeletePatientNoteById(int encounterId, int id);
    }
}
