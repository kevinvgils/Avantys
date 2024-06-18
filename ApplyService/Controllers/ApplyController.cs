using ApplyService.Domain;
using ApplyService.DomainServices;
using ApplyService.Models;
using EventLibrary;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace ApplyService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplyController : ControllerBase
    {
        private readonly IBus _IBus;
        private readonly IApplyRepository _applyRepository;

        public ApplyController(IBus bus, IApplyRepository applyRepository)
        {
            _IBus = bus;
            _applyRepository = applyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Apply(IApply application)
        {
            var applicant = new Applicant();
            applicant.Name = application.Name;
            applicant.Email = application.Email;
            applicant.IsAccepted = false;
            applicant.ApplyDate = DateTime.UtcNow;
            await _applyRepository.AddApplicant(applicant);

            ApplicantCreated ac = new();
            ac.Name = application.Name;
            ac.Email = application.Email;
            ac.StudyProgram = application.StudyProgram;
            ac.ApplicantId = applicant.ApplicantId;

            // Publiceer het evenement
            await _IBus.Publish(ac);

            Console.WriteLine("ENDPOINT PUBLHISHED");

            return Ok();
        }
    }
}
