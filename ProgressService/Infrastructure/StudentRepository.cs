using Eventlibrary;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using System.Collections.Immutable;

namespace Infrastructure
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ProgressDbContext _context;

        public StudentRepository(ProgressDbContext context)
        {
            _context = context;
        }


        public async Task<Student> createStudent(Student Student)
        {
            await _context.Students.AddAsync(Student);
            return Student;
        }

        public IEnumerable<Student> getAllStudents()
        {
            return _context.Students.ToImmutableArray();
        }
    }
}
