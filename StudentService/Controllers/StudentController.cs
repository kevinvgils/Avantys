using Microsoft.AspNetCore.Mvc;
using StudentService.Domain;
using StudentService.DomainServices.Interfaces;

namespace StudentService.Controllers
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
    }
}