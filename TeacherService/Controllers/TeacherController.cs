using System.Collections.Generic;
using System.Threading.Tasks;
using DomainServices;
using TeacherService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace TeacherService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> Get()
        {
            return await _repository.GetAllTeachers();
        }

        [HttpGet("{id}")]
        public async Task<Teacher> Get(int id)
        {
            return await _repository.GetTeacherById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Teacher teacher)
        {
            await _repository.AddTeacher(teacher);
            return CreatedAtAction(nameof(Get), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateTeacher(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteTeacher(id);
            return NoContent();
        }
    }
}
