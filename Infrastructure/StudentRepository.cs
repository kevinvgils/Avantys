using Domain.Users;
using DomainServices;

namespace Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
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
