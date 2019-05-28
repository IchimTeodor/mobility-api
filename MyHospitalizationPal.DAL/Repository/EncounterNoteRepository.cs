using Microsoft.EntityFrameworkCore;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    class EncounterNoteRepository : Repository<EncounterNote>, IEncounterNoteRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }

        public EncounterNoteRepository(ApplicationContext context) : base(context)
        {

        }

        public void Create(EncounterNote entity)
        {
            Context.EncounterNote.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var encounterNote = Context.EncounterNote.SingleOrDefault(p => p.Id == id);
            Context.EncounterNote.Remove(encounterNote);
            Context.SaveChanges();
        }

        public EncounterNote Details(int id)
        {
            var encounterNote = Context.EncounterNote.SingleOrDefault(p => p.Id == id);
            return encounterNote;
        }

        public void Edit(EncounterNote entity)
        {
            Context.EncounterNote.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<EncounterNote> GetAll()
        {
            var encounterNote = Context.EncounterNote.ToList();
            return encounterNote;
        }

        public EncounterNote GetEncounterId(int encounterId, int id)
        {
            var encounterNote = Context.EncounterNote.SingleOrDefault(en => en.EncounterId == encounterId && en.Id == id);
            return encounterNote;
        }


        public IEnumerable<EncounterNote> ListOfEncounterNoteByEncounterId(int encounterId)
        {
            var encounterNote = Context.EncounterNote
                .Where(en => en.EncounterId == encounterId)
                .Include(a => a.Feeling)
                .ToList();
            if (encounterNote == null)
            {
                throw new Exception($"No encounterNote found for {encounterId}!");
            }

            return encounterNote;
        }
    }
}
