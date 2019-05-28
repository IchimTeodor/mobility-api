using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.DAL.Repository;
using MyHospitalizationPal.Server.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHospitalizationPal.Server.Services.PatientNotes
{

    public class PatientNotesService : IPatientNotesService
    {
        public IUnitOfWork UnitOfWork = null;
        public PatientNotesService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork as UnitOfWork;
        }


        public IEnumerable<PatientNoteDt> GetNotes(int encounterId, int? limit)
        {

            var patientNote = UnitOfWork.PatientNoteRepository.DetailsForPatientNotes(encounterId, limit);

            if (patientNote == null)
            {
                throw new Exception($"No notes found for encounterId {encounterId}");
            }

            return patientNote;

        }


        public IEnumerable<PatientNoteDt> GetAllNotes(int encounterId)
        {

            var notes = UnitOfWork.PatientNoteRepository.AllNotesDetails(encounterId);

            if (notes == null)
            {
                throw new Exception($"No notes found for encounterId {encounterId}");
            }

            return notes;
         
        }


        public PatientNoteDt GetNoteById(int encounterId, int id)
        {
            var noteById = UnitOfWork.PatientNoteRepository.GetNoteById(encounterId,id);
            if (noteById == null)
            {
                throw new Exception($"No notes found for encounterId {encounterId}");
            }

            return noteById;
        }




        public PatientNoteDt AddNotes(PatientNoteAdd patientNoteAdd)
        {
            var encounter = UnitOfWork.PatientNoteRepository.GetEncounter(patientNoteAdd.EncounterId);
            if(encounter == null)
            {
                throw new Exception($"No encounter found for {patientNoteAdd.EncounterId}");
            }

            UnitOfWork.EncounterNoteRepository
                .Create(patientNoteAdd
                    .AddNewNote());

            return GetAllNotes(encounter.Id).Last();

        }


        public void UpdatePatientNoteById(PatientNoteDt patientNoteDetails, int encounterId, int id)
        {
            var encounter = UnitOfWork.PatientNoteRepository.GetEncounter(encounterId);
            if (encounter == null)
            {
                throw new Exception($"No encounter found for {encounterId}");
            }

            var encounterNote = UnitOfWork.EncounterNoteRepository.GetEncounterId(encounter.Id, patientNoteDetails.Id);

            var feelings = UnitOfWork.FeelingRepository.GetFeelingByEncounterNoteId(encounterNote.Id).ToList();



            encounterNote.Comment = patientNoteDetails.Comment;
            encounterNote.DateOfDocumentation = patientNoteDetails.DateOfDocumentation;

            foreach (var feeling in feelings)
            {
                feeling.Value = patientNoteDetails.FeelingMode
                    .FirstOrDefault(p => p.FeelingType == feeling.FeelingType).Value;
                UnitOfWork.FeelingRepository
                  .Edit(feeling);
            }
            
            UnitOfWork.EncounterNoteRepository
                .Edit(encounterNote);

            UnitOfWork.Commit();

        }


        public void DeletePatientNoteById(int encounterId, int id)
        {
            var encounter = UnitOfWork.PatientNoteRepository.GetEncounter(encounterId);
            if (encounter == null)
            {
                throw new Exception($"No encounter found for {encounterId}");
            }
            var encounterNote = UnitOfWork.EncounterNoteRepository.GetEncounterId(encounter.Id, id);

            var feelings = UnitOfWork.FeelingRepository.GetFeelingByEncounterNoteId(encounterNote.Id);

            foreach (var feeling in feelings)
            {
                UnitOfWork.FeelingRepository
               .Delete(feeling.Id);
            }
           
            UnitOfWork.EncounterNoteRepository
                .Delete(encounterNote.Id);
            UnitOfWork.Commit();
        }
    }
}
