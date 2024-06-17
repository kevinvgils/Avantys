using Domain.Events;
using Domain.Users;
using DomainServices;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;

namespace ApplyService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplyController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IApplyRepository _applyRepository;

        public ApplyController(IPublishEndpoint publishEndpoint, IApplyRepository applyRepository)
        {
            _publishEndpoint = publishEndpoint;
            _applyRepository = applyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Apply(IApply application)
        {
            // Logica voor het verwerken van de aanmelding
            // ...

            var applicant = new Applicant();
            applicant.Name = application.Naam;
            applicant.Email = application.Email;
            await _applyRepository.AddApplicant(applicant);

            // Publiceer het evenement
            await _publishEndpoint.Publish<IApplicantCreatedEvent>(new
            {
                applicant.Name
            });

            return Ok();
        }
    }
}
