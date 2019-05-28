using MyHospitalizationPal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHospitalizationPal.DAL.Interfaces
{
    public interface IEncounterRepository : IRepository<Encounter>
    {

        void Create(Encounter entity);
        void Delete(int id);
        Encounter Details(int id);
        void Edit(Encounter entity);
        IEnumerable<Encounter> GetAll();
        Encounter GetEncounterByUniqueCodeId(string uniqueCodeId);
        Encounter AddPatientNoteByEncounterId(int encounterId);


    }
}
