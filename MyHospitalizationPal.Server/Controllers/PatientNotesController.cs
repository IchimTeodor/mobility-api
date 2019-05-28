using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHospitalizationPal.DAL.Aggregates;
using MyHospitalizationPal.Server.Services.PatientNotes;
using MyHospitalizationPal.Server.Services.Register;

namespace MyHospitalizationPal.Server.Controllers
{
    [Route("api/encounters")]
    [ApiController]
    public class PatientNotesController : Controller
    {
        private IPatientNotesService patientNoteService;

        public PatientNotesController(IPatientNotesService patientNoteService)
        {
            this.patientNoteService = patientNoteService;
        }



        [HttpGet, Route("{encounterId:int}/notes/review")]
        public IActionResult Details(int encounterId, int? limit)
        {
            
            var noteDetails = patientNoteService.GetNotes(encounterId, limit);

            return Ok(noteDetails);
        }


        [HttpGet, Route("{encounterId:int}/notes")]
        public IActionResult AllNotesDetails(int encounterId)
        {

            var notes = patientNoteService.GetAllNotes(encounterId);

            return Ok(notes);
        }



        [HttpGet, Route("{encounterId:int}/notes/{id}")]
        public IActionResult GetNoteById(int encounterId, int id)
        {
            try
            {
                var notesById = patientNoteService.GetNoteById(encounterId, id);

                return Ok(notesById);
            }
            catch(Exception e)
            {
                return Ok(e.Message.ToString());
            }
            
        }


        [HttpPost, Route("{encounterId:int}/notes")]
        public IActionResult AddNote([FromBody]PatientNoteAdd patientNoteAdd)
        {
            return Ok(patientNoteService.AddNotes(patientNoteAdd));

        }


        [HttpPut, Route("{encounterId:int}/notes/{id}")]
        public IActionResult UpdateNotes([FromBody]PatientNoteDt patientNoteDetails, int encounterId, int id) 
        {
            try
            {
                patientNoteService.UpdatePatientNoteById(patientNoteDetails, encounterId, id);
                return Ok("UPDATED!");
            }
            catch (Exception e)
            {
                return Ok(e.Message.ToString());
            }
            
        }


        [HttpDelete, Route("{encounterId:int}/notes/{id}")]
        public IActionResult DeleteNotes(int encounterId, int id)
        {
            try
            {
                patientNoteService.DeletePatientNoteById(encounterId, id);
                return Ok("DELETED!");
            }
            catch (Exception e)
            {
                return Ok(e.Message.ToString());
            }
            
        }
    }
}