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

            var result = new
            {
                InterviewId = updatedInterview.InterviewId.ToString().ToUpper(),
                ApplicantId = updatedInterview.ApplicantId.ToString().ToUpper(),
                updatedInterview.Comments,
                updatedInterview.ScheduledDate, 
                updatedInterview.Status
            };

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterviews()
        {
            var interviews = await _interviewService.GetAllInterviewsAsync();

            var result = interviews.Select(interview => new
            {
                InterviewId = interview.InterviewId.ToString().ToUpper(),
                ApplicantId = interview.ApplicantId.ToString().ToUpper(),
                interview.Comments,
                interview.ScheduledDate,
                interview.Status
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewById(Guid id)
        {
            var interview = await _interviewService.GetInterviewByIdAsync(id);

            if (interview == null)
            {
                return NotFound("Interview not found");
            }

            var result = new
            {
                InterviewId = interview.InterviewId.ToString().ToUpper(),
                ApplicantId = interview.ApplicantId.ToString().ToUpper(),
                interview.Comments,
                interview.ScheduledDate,
                interview.Status
            };

            return Ok(result);
        }
        [HttpGet("applicantId")]
        public async Task<IActionResult> GetInterviewByApplicantId([FromBody] GetByApplicantIdModel model)
        {
            var interview = await _interviewService.GetInterviewByApplicantIdAsync(model.ApplicantId);

            if (interview == null)
            {
                return NotFound("Interview not found");
            }

            var result = new
            {
                InterviewId = interview.InterviewId.ToString().ToUpper(),
                ApplicantId = interview.ApplicantId.ToString().ToUpper(),
                interview.Comments,
                interview.ScheduledDate,
                interview.Status
            };

            return Ok(result);
        }

    }
}