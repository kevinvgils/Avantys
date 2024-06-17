using Domain.Users;
using DomainServices;
using Microsoft.AspNetCore.Mvc;

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