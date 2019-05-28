using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Repository
{
    class FeelingRepository : Repository<Feeling>, IFeelingRepository
    {
        private ApplicationContext Context
        {
            get
            {
                return db as ApplicationContext;
            }
        }
        public FeelingRepository(ApplicationContext context) : base(context)
        {
            
        }

        public void Create(Feeling entity)
        {
            Context.Feeling.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var feeling = Context.Feeling.SingleOrDefault(p => p.Id == id);
            Context.Feeling.Remove(feeling);
            Context.SaveChanges();
        }

        public Feeling Details(int id)
        {
            var feeling = Context.Feeling.SingleOrDefault(p => p.Id == id);
            return feeling;
        }

        public void Edit(Feeling entity)
        {
            Context.Feeling.Update(entity);
            Context.SaveChanges();
        }

        public void EditList(IEnumerable<Feeling> entityList)
        {
            Context.Feeling.Update(entityList.FirstOrDefault());
            Context.SaveChanges();
        }

        public IEnumerable<Feeling> GetAll()
        {
            var feeling = Context.Feeling.ToList();
            return feeling;
        }

        public IEnumerable<Feeling> GetFeelingByEncounterNoteId(int encounterNoteId)
        {
            var feeling = Context.Feeling.Where(f => f.EncounterNoteId == encounterNoteId);
            return feeling;
        }
    }
}
