using Domain.Users;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;

namespace ProgressService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplyController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ApplyController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> MeldAan([FromBody] Applicant aanmelding)
        {
            // Logica voor het verwerken van de aanmelding
            // ...

            // Publiceer het evenement
            await _publishEndpoint.Publish<IApplicantCreatedEvent>(new
            {
                aanmelding.StudentId,
                aanmelding.Naam,
                aanmelding.Email,
                aanmelding.Studieprogramma
            });

            return Ok();
        }
    }
}
