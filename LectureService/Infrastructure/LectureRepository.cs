using LectureService.Domain;
using LectureService.DomainServices;
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
            return await _context.Lectures.FirstOrDefaultAsync(l => l.Id == lectureId);
        }

        public async Task UpdateLecture(Lecture lecture)
        {
            _context.Lectures.Update(lecture);
            await _context.SaveChangesAsync();
        }

        public async Task AddTeacher(Guid teacherId, Guid lectureId)
        {
            var lecture = await _context.Lectures.FirstOrDefaultAsync(l => l.Id == lectureId);
            if (lecture == null)
            {
                throw new ArgumentException($"Lecture with ID {lectureId} not found.");
            }

            lecture.TeacherId = teacherId;
            _context.Lectures.Update(lecture);
            await _context.SaveChangesAsync();
        }

        public Guid GetTeacher()
        {
            return _context.Lectures.FirstOrDefault().TeacherId;
        }

        public async Task AddClass(Guid classId, Guid lectureId)
        {
            var lecture = await _context.Lectures.FirstOrDefaultAsync(l => l.Id == lectureId);
            if (lecture == null)
            {
                throw new ArgumentException($"Lecture with ID {lectureId} not found.");
            }

            lecture.ClassId = classId;
            _context.Lectures.Update(lecture);
            await _context.SaveChangesAsync();
        }

        public Guid GetClass()
        {
            return _context.Lectures.FirstOrDefault().ClassId;
        }
    }
}
