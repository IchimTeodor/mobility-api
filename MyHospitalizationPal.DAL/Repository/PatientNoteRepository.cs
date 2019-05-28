using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHospitalizationPal.DAL.Repository
{
    public class PatientNoteRepository : Repository<PatientNoteRepository>, IPatientNoteRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public PatientNoteRepository(ApplicationContext context) : base(context)
        {

        }


        public IEnumerable<PatientNoteDt> DetailsForPatientNotes(int encounterId, int? limit)
        {

            var encounterNotes = from e in Context.Encounter
                                where (e.Id == encounterId)
                                join en in Context.EncounterNote
                                on e.Id equals en.EncounterId
                                select new
                                {
                                    en.Id,
                                    en.Comment,
                                    en.DateOfDocumentation,
                                    en.Feeling
                                };

            if (limit.HasValue)
            {
                encounterNotes = encounterNotes.Take(limit.Value);
            }

            var filteredNotes = encounterNotes.ToList();

            var notes = filteredNotes.Select(n => new PatientNoteDt()
            {
                Id = n.Id,
                Comment = n.Comment,
                DateOfDocumentation = n.DateOfDocumentation,
                FeelingMode = n.Feeling.Select(f => new FeelingMode
                {
                    FeelingType = f.FeelingType,
                    Value = f.Value
                })
                .ToList()
            })
            .ToList();

            return notes;
        }


        public IEnumerable<PatientNoteDt> AllNotesDetails(int encounterId)
        {

            var encounterNote = from e in Context.Encounter
                                where (e.Id == encounterId)
                                join en in Context.EncounterNote
                                on e.Id equals en.EncounterId
                                select new
                                {
                                    en.Id,
                                    en.Comment,
                                    en.DateOfDocumentation,
                                    en.Feeling
                                };


            var notes = encounterNote.Select(n => new PatientNoteDt
            {
                Id = n.Id,
                Comment = n.Comment,
                DateOfDocumentation = n.DateOfDocumentation,
                FeelingMode = Context.Feeling.Where(f => f.EncounterNoteId == n.Id).Select(e => new FeelingMode()
                {
                    FeelingType = e.FeelingType,
                    Value = e.Value
                })
                .ToList()
            }
            )
            .ToList();

            return notes;
        }



        public PatientNoteDt GetNoteById(int encounterId, int id)
        {

            var encounter = Context.Encounter.SingleOrDefault(e => e.Id == encounterId);
            if (encounter == null)
            {
                throw new Exception($"No encounter found for encounterId {encounterId}");
            }

            var encounterNote = Context.EncounterNote.SingleOrDefault(en => en.EncounterId == encounter.Id && en.Id == id);
            if (encounterNote == null)
            {
                throw new Exception($"No note found for encounterNoteId {id}");
            }
            
            var feeling = Context.Feeling.Where(f => f.EncounterNoteId == encounterNote.Id).ToList();


            return new PatientNoteDt
            {
                Id = encounterNote.Id,
                Comment = encounterNote.Comment,
                DateOfDocumentation = encounterNote.DateOfDocumentation,
                FeelingMode = feeling.Select(e => new FeelingMode()
                {
                    FeelingType = e.FeelingType,
                    Value = e.Value
                }).ToList()
            };

        }


        public Encounter GetEncounter(int encounterId)
        {
            return Context.Encounter.SingleOrDefault(e => e.Id == encounterId);
        }

    }
}
