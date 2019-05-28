using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IPatientNoteRepository
    {
       IEnumerable<PatientNoteDt> DetailsForPatientNotes(int encounterId, int? limit);

      IEnumerable<PatientNoteDt> AllNotesDetails(int encounterId);

      PatientNoteDt GetNoteById(int encounterId, int id);

      Encounter GetEncounter(int encounterId);

    }
}
