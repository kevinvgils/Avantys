using EventLibrary;
using MassTransit;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;
using Infrastructure;

namespace DomainServices
{
    public class StudentsService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IStudyProgramRepository _studyProgramRepository;
        private readonly IBusControl _serviceBus;


        public StudentsService(IStudentRepository repo, IClassRepository classRepository, IStudyProgramRepository studyProgramRepository, IBusControl serviceBus)
        {
            _studentRepository = repo;
            _serviceBus = serviceBus;
            _classRepository = classRepository;
            _studyProgramRepository = studyProgramRepository;
        }

        public async Task<Student> AssignStudentToClassAsync(Student student)
        {
            var classEntity = await _classRepository.GetByIdAsync((Guid)student.ClassId);
            if (classEntity == null)
            {
                throw new Exception($"Class with ID {student.ClassId} does not exist.");
            }

            student.StudyProgramId = classEntity.StudyProgramId;

            var studyProgramExists = await _studyProgramRepository.ExistsAsync((Guid)student.StudyProgramId);
            if (!studyProgramExists)
            {
                throw new Exception($"Study program with ID {student.StudyProgramId} does not exist.");
            }

            var studentCreated = new StudentCreated()
            {
                StudentId = student.StudentId,
                ClassId = (Guid)student.ClassId,
                Name = student.Name,
                Email = student.Email,
                StudyProgramId = (Guid)student.StudyProgramId
            };
            await _serviceBus.Publish(studentCreated, context =>
            {
                context.SetRoutingKey("student.created");
            });
            return student;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudents();
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(Guid studentId)
        {
            var student = await _studentRepository.GetStudent(studentId);
            return student;
        }
    }
}
