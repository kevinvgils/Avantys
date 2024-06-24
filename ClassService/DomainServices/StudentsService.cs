using EventLibrary;
using MassTransit;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace DomainServices
{
    public class StudentsService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IBusControl _serviceBus;


        public StudentsService(IStudentRepository repo, IBusControl serviceBus)
        {
            _studentRepository = repo;
            _serviceBus = serviceBus;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            await _studentRepository.AddStudent(student);

            var studentCreated = new StudentCreated()
            {
                StudentId = student.StudentId,
                ClassId = (Guid)student.ClassId,
                Name = student.Name,
                Email = student.Email,
                StudyProgramId = (Guid)student.StudyProgramId
            };

            await _serviceBus.Publish(studentCreated);

            return student;
        }
    }
}
