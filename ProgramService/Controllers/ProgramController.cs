using Microsoft.AspNetCore.Mvc;
using ProgramService.Domain;
using ProgramService.DomainServices.Interfaces;

namespace ProgramService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _ProgramService;

        public ProgramController(IProgramService ProgramService)
        {
            _ProgramService = ProgramService;
        }

        [HttpGet]
        public IEnumerable<StudyProgram> GetAllProgram()
        {
            return _ProgramService.GetAllPrograms();
        }

        [HttpPost]
        public async Task CreateProgram(StudyProgram program) {
            await _ProgramService.CreateProgram(program);
        }
    }
}