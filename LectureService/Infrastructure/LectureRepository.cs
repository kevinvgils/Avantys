using LectureService.Domain;
using LectureService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LectureService.Infrastructure
{
    public class LectureRepository : ILectureRepository
    {
        private readonly LectureDbContext _context;

        public LectureRepository(LectureDbContext context)
        {
            _context = context;
        }

        public async Task AddLecture(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            await _context.SaveChangesAsync();
        }

        public async Task<Lecture> GetLectureById(Guid lectureId)
        {
            return await _context.Lectures.FirstOrDefaultAsync(l => l.LectureId == lectureId);
        }

        public async Task<List<Lecture>> GetAllLecturesAsync()
        {
            return await _context.Lectures.ToListAsync();
        }

        public async Task<bool> DeleteLectureAsync(Guid lectureId)
        {
            var lecture = await _context.Lectures.FindAsync(lectureId);
            if (lecture == null)
            {
                return false;
            }

            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _context.Classes.ToListAsync();
        }


        public async Task AddClass(Class @class)
        {
            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();
        }

        public async Task AssignClassAsync(Guid classId, Guid lectureId)
        {
            var lecture = await _context.Lectures.FirstOrDefaultAsync(l => l.LectureId == lectureId);
            if (lecture == null)
            {
                throw new ArgumentException("Lecture not found");
            }

            lecture.ClassId = classId;

            await _context.SaveChangesAsync();
        }
    }
}
