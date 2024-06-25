using Eventlibrary;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using ProgressService.Infrastructure;
using System.Collections.Immutable;

namespace Infrastructure
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ProgressDbContext _context;
        private readonly IProgramRepository _programRepository;

        public StudentRepository(ProgressDbContext context, IProgramRepository programRepository)
        {
            _context = context;
            _programRepository = programRepository;
        }


        public async Task<Student> CreateStudent(Student Student)
        {
            await _context.Students.AddAsync(Student);
            return Student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToImmutableArray();
        }

        public IEnumerable<Student> GetAllStudents(string module)
        {
            IEnumerable<Student> students = GetAllStudents(); // Assuming GetAllStudents() retrieves all students

            // Filter students based on the module condition
            return students.Where(student =>
            {
                StudyProgram program = _programRepository.GetPrograms(student.ProgramId);
                return program != null && program.Subjects.Contains(module);
            }).ToList();
        }
    }
}
