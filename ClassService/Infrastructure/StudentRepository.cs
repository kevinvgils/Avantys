using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ClassDbContext _context;

        public StudentRepository(ClassDbContext context)
        {
            _context = context;
        }

        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public Student GetStudent()
        {
            return _context.Students.SingleOrDefault();
        }
    }
}
