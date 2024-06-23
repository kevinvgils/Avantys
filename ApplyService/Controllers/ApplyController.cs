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
            var createdApplicant = await _applyService.CreateApplicantAsync(applicant);

            return Ok(createdApplicant);
        }
    }
}
