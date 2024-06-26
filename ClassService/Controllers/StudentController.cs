using Microsoft.AspNetCore.Mvc;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;
using ClassService.Models;

namespace ClassService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();

            var studentModels = ToStudentModels(students);

            return Ok(studentModels);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AssignStudentToClass(Guid id, [FromBody]StudentAssignModel studentAssignModel)
        {
            var studentToUpdate = await _studentService.GetStudentByIdAsync(id);
            studentToUpdate.ClassId = studentAssignModel.ClassId;
            var updatedStudent = await _studentService.AssignStudentToClassAsync(studentToUpdate);

            var student = ToStudentModel(updatedStudent);

            return Ok(student);
        }

        private StudentModel ToStudentModel(Student student)
        {
            return new StudentModel
            {
                StudentId = student.StudentId.ToString().ToUpper(),
                ClassId = student.ClassId.ToString().ToUpper(),
                Name = student.Name,
                Email = student.Email,
                StudyProgramId = student.StudyProgramId.ToString().ToUpper()
            };
        }
        private IEnumerable<StudentModel> ToStudentModels(IEnumerable<Student> students)
        {
            return students.Select(s => ToStudentModel(s)).ToList();
        }

    }
}