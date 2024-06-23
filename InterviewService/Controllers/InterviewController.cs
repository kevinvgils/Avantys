using InterviewService.Domain;
using InterviewService.DomainServices.Interfaces;
using InterviewService.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace InterviewService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EndInterview(Guid id, [FromBody] IEndInterview endInterview)
        {
            if (endInterview.Status != "Accepted" && endInterview.Status != "Declined")
            {
                return BadRequest("Status must be 'Accepted' or 'Declined'");
            }
            var interview = new Interview();
            interview.Status = endInterview.Status;
            interview.Comments = endInterview.Comments;
            var updatedInterview = await _interviewService.UpdateInterviewAsync(id, interview);

            if (updatedInterview == null)
            {
                return NotFound("Interview not found");
            }

            return Ok(updatedInterview);

        }

    }
}