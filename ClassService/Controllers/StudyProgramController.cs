using Microsoft.AspNetCore.Mvc;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using ClassService.Models;

namespace ClassService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyProgramController : ControllerBase
    {
        private readonly IStudyProgramService _studyProgramService;

        public StudyProgramController(IStudyProgramService studyProgramService)
        {
            _studyProgramService = studyProgramService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudyProgramAsync(StudyProgramModel newStudyProgram)
        {
            var studyProgram = new StudyProgram();
            studyProgram.Name = newStudyProgram.Name;
            studyProgram.Subjects = newStudyProgram.Subjects;
            var createdStudyProgram = await _studyProgramService.CreateStudyProgramAsync(studyProgram);

            return Ok(createdStudyProgram);
        }

    }
}