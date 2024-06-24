using Microsoft.AspNetCore.Mvc;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace ClassService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public Student GetStudent()
        {
            return _studentRepository.GetStudent();
        }

        [HttpPut]
        public Student AddStudentToProgram()
        {
            return _studentRepository.GetStudent();
        }
    }
}