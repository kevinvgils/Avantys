using EventLibrary;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace ProgressService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _ProgressRepository;

        private readonly ITestRepository _TestRepository;
        private readonly IStudentRepository _StudentRepository;
        private readonly IProgramRepository _ProgramRepository;

        private readonly ILogger<ProgressController> _logger; // Inject ILogger<T>

        public ProgressController( IProgressRepository ProgressRepository,
            ITestRepository TestRepository,
            ILogger<ProgressController> logger,
            IStudentRepository studentRepository,
            IProgramRepository programRepository)
        {
            _ProgressRepository = ProgressRepository;
            _logger = logger;
            _TestRepository = TestRepository;
            _StudentRepository = studentRepository;
            _ProgramRepository = programRepository;
        }

        [HttpGet]
        public IEnumerable<Progress> GetProgress()
        {
            return _ProgressRepository.getAllProgress();
        }

        [HttpGet("{ProgressId}")]
        public Progress GetProgress(string ProgressId)
        {
            return _ProgressRepository.getProgress(new Guid(ProgressId));
        }

        [HttpPut("{ProgressId}/Grade")]
        public void GradeProgress(string ProgressId, Progress progress)
        {
            progress.Id = new Guid(ProgressId);
            _ProgressRepository.gradeProgress(progress);
        }

        //TEST ENDPOINTS
        [HttpGet("tests")]
        public IActionResult GetTests() // Changed return type to IActionResult
        {
            try
            {
                _logger.LogInformation("Fetching all tests...");

                var tests = _TestRepository.GetAllTests();

                _logger.LogInformation($"Retrieved {tests.Count()} tests successfully.");

                return Ok(tests);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching tests: {ex.Message}");
                return StatusCode(500, "Internal server error"); // Return a 500 status code in case of error
            }
        }

        [HttpGet("studies")]
        public IActionResult GetStudies() // Changed return type to IActionResult
        {
            try
            {
                _logger.LogInformation("Fetching all studies...");

                IEnumerable<StudyProgram> programs = _ProgramRepository.GetAllPrograms();

                _logger.LogInformation($"Retrieved {programs.Count()} studies successfully.");

                return Ok(programs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching studies: {ex.Message}");
                return StatusCode(500, "Internal server error"); // Return a 500 status code in case of error
            }
        }

        [HttpGet("students")]
        public IActionResult GetStudents() // Changed return type to IActionResult
        {
            try
            {
                _logger.LogInformation("Fetching all students...");

                var students = _StudentRepository.GetAllStudents();

                _logger.LogInformation($"Retrieved {students.Count()} students successfully.");

                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching students: {ex.Message}");
                return StatusCode(500, "Internal server error"); // Return a 500 status code in case of error
            }
        }
    }
}