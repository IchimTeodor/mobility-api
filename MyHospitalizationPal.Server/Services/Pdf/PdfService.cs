using System;
using System.Collections.Generic;
using System.IO;
using MyHospitalizationPal.Server.Models;

namespace MyHospitalizationPal.Server.Services.Pdf
{
    public class PdfService : IPdfService
    {
        //public void ConvertPdf(byte[] pdf)
        //{
        //    File.WriteAllBytes(@".\PdfFile\EXEMPLU2.pdf", pdf);
        //}

        public IEnumerable<ResultsMetadata> ResultsMetadata()
        {
            List<ResultsMetadata> list = new List<ResultsMetadata>();
            List<string> results = new List<string>
            {
                "Blood tests",
                "Labs",
                "Treatment",
                "Prescription"
            };
            Random rm = new Random();
            int value = rm.Next(4);
            while(value == 0)
            {
                value = rm.Next(4);
            }
            for(int i = 1; i <= value; i++)
            {
                list.Add(new Models.ResultsMetadata
                {
                    Date = new DateTime(2018, 07, 13).AddDays(i),
                    ResultDescription = results[i - 1]
                });
            }
            return list;
        }
    }
}
