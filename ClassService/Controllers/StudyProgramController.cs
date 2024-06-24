using Microsoft.AspNetCore.Mvc;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace ClassService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public ClassController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

    }
}