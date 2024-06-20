using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingService.Domain;
using MeetingService.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace MeetingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeetingController : ControllerBase
{
    private readonly IMeetingRepository _repository;

    public MeetingController(IMeetingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Meeting>> Get()
    {
        return await _repository.GetAllMeetings();
    }

    [HttpGet("{id}")]
    public async Task<Meeting> Get(int id)
    {
        return await _repository.GetMeetingById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Meeting meeting)
    {
        await _repository.AddMeeting(meeting);
        return CreatedAtAction(nameof(Get), new { id = meeting.Id }, meeting);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] Meeting meeting)
    {
        if (id != meeting.Id)
        {
            return BadRequest();
        }

        await _repository.UpdateMeeting(meeting);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteMeeting(id);
        return NoContent();
    }
}
