using MyHospitalizationPal.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalizationPal.Server.Services.Pdf
{
    public interface IPdfService
    {
        IEnumerable<ResultsMetadata> ResultsMetadata(); 

    }
}
