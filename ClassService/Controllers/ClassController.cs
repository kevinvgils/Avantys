using Microsoft.AspNetCore.Mvc;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;
using ClassService.Models;
using DomainServices;

namespace ClassService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClassAsync(ClassModel newClass)
        {
            var @class = new Class();
            @class.ClassCode = newClass.ClassCode;
            @class.StudyProgramId = newClass.StudyProgramId;
            var createdClass = await _classService.CreateClassAsync(@class);

            var result = new
            {
                createdClass.ClassCode,
                StudyProgramId = createdClass.StudyProgramId.ToString().ToUpper(),
                ClassId = createdClass.ClassId.ToString().ToUpper()
            };

            return Ok(result);
        }

    }
}