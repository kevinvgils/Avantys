using ClassService.Domain;
using ClassService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Student>> GetAllStudents()
        {
            var students = _context.Students.ToList();
            return students;
        }

        public async Task<Student> GetStudent(Guid studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task UpdateStudent(Student updatedStudent)
        {
            // Ensure the student exists in the database
            var existingStudent = await _context.Students.FindAsync(updatedStudent.StudentId);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            _context.Entry(existingStudent).CurrentValues.SetValues(updatedStudent);

            await _context.SaveChangesAsync();
        }

    }
}
