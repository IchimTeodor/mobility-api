using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyHospitalizationPal.Server.Services.Pdf;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class ResultsPDFController : Controller
    {
        public IPdfService pdfService = null;
        private readonly IOptions<AppSettings> appSettings;
        public ResultsPDFController(IOptions<AppSettings> appSettings, IPdfService pdfService)
        {
            this.appSettings = appSettings;
            this.pdfService = pdfService;
        }
        [HttpGet, Route("results/metadata")]
        public IActionResult GetResultsMetadata()
        {
            
            return Ok(pdfService.ResultsMetadata());
        }


        [HttpGet, Route("results/pdf")]
        public IActionResult GetResultsPfd()
        {
            Random rm = new Random();
            int value = rm.Next(4);
            var stream = new FileStream($"{appSettings.Value.PdfPath}/pdf{value.ToString()}.pdf", FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");

        }
    }
}