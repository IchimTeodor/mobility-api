using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.Server.Extensions;
using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.FeelingsGraphic
{
    public class FeelingsGraphicService : IFeelingsGraphicService
    {
        private IUnitOfWork unitOfWork = null;

        public FeelingsGraphicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



        public IEnumerable<FeelingsGroup> ListOfFeelingGroup(int encounterId)
        {

            var encounter = unitOfWork.EncounterRepository.AddPatientNoteByEncounterId(encounterId);
            if (encounter == null)
            {
                throw new Exception($"No encounter found for {encounterId} !");
            }

            var encounterNote = unitOfWork.EncounterNoteRepository.ListOfEncounterNoteByEncounterId(encounter.Id);

            var feelingsGroup = encounterNote
             .SelectMany(en => en.Feeling.GroupBy(f => f.FeelingType))
             .Select(a => a.FeelingsGroupExtension());

            return feelingsGroup;
        }

    }
}
