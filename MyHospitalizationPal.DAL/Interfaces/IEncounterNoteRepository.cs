using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IEncounterNoteRepository : IRepository<EncounterNote>
    {
        void Create(EncounterNote entity);
        void Delete(int id);
        EncounterNote Details(int id);
        void Edit(EncounterNote entity);
        IEnumerable<EncounterNote> GetAll();
        EncounterNote GetEncounterId(int encounterId, int id);
        IEnumerable<EncounterNote> ListOfEncounterNoteByEncounterId(int encounterId);
    }
}
