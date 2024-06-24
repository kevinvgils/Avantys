using Microsoft.AspNetCore.Mvc;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace ClassService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyProgramController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudyProgramController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

    }
}