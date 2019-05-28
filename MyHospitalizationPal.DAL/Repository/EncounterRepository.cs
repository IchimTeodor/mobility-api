using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    class EncounterRepository : Repository<Encounter>, IEncounterRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public EncounterRepository(ApplicationContext context) : base(context)
        {

        }

        public void Create(Encounter entity)
        {
            Context.Encounter.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var encounter = Context.Encounter.SingleOrDefault(p => p.Id == id);
            Context.Encounter.Remove(encounter);
            Context.SaveChanges();
        }

        public Encounter Details(int id)
        {
            var encounter = Context.Encounter.SingleOrDefault(p => p.Id == id);
            return encounter;
        }

        public void Edit(Encounter entity)
        {
            Context.Encounter.Update(entity);
            Context.SaveChanges();
        }

        public IEnumerable<Encounter> GetAll()
        {
            var encounter = Context.Encounter.ToList();
            return encounter;
        }

        public Encounter GetEncounterByUniqueCodeId(string uniqueCodeId)
        {
            return Context.Encounter.SingleOrDefault(e => e.BraceletTagId.Equals(uniqueCodeId));
        }

        public Encounter AddPatientNoteByEncounterId(int encounterId)
        {
            return Context.Encounter.SingleOrDefault(e => e.Id == encounterId);
        }
    }
}

