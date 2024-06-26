using ApplyService.Domain;
using ApplyService.DomainServices;
using ApplyService.DomainServices.Interfaces;
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
        private readonly IApplyService _applyService;

        public ApplyController(IBus bus, IApplyService applyService)
        {
            _IBus = bus;
            _applyService = applyService;
        }

        [HttpPost]
        public async Task<IActionResult> Apply(IApply application)
        {
            var applicant = new Applicant();
            applicant.Name = application.Name;
            applicant.Email = application.Email;
            applicant.IsAccepted = false;
            applicant.ApplyDate = DateTime.UtcNow;
            applicant.StudyProgram = application.StudyProgram;
            var createdApplicant = await _applyService.CreateApplicantAsync(applicant);

            var result = new
            {
                ApplicantId = createdApplicant.ApplicantId.ToString().ToUpper(),
                createdApplicant.Name,
                createdApplicant.Email,
                createdApplicant.IsAccepted,
                createdApplicant.ApplyDate,
                createdApplicant.StudyProgram
            };

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Applicant>>> GetAllApplicants()
        {
            var applicants = await _applyService.GetAllApplicantsAsync();

            var result = applicants.Select(applicant => new
            {
                ApplicantId = applicant.ApplicantId.ToString().ToUpper(),
                applicant.Name,
                applicant.ApplyDate,
                applicant.IsAccepted,
                applicant.StudyProgram,
                applicant.Email
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicantById(Guid id)
        {
            var applicant = await _applyService.GetApplicantByIdAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return Ok(applicant);
        }
    }
}
