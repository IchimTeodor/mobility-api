using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IFeelingRepository : IRepository<Feeling>
    {
        void Create(Feeling entity);
        void Delete(int id);
        Feeling Details(int id);
        void Edit(Feeling entity);
        void EditList(IEnumerable<Feeling> entityList);
        IEnumerable<Feeling> GetAll();
        IEnumerable<Feeling> GetFeelingByEncounterNoteId(int encounterNoteId);
    }
}
