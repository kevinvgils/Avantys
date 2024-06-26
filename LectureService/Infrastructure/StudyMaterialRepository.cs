using LectureService.Domain;
using LectureService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LectureService.Infrastructure
{
    public class StudyMaterialRepository : IStudyMaterialRepository
    {
        private readonly LectureDbContext _context;

        public StudyMaterialRepository(LectureDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudyMaterial(StudyMaterial studyMaterial)
        {
            _context.StudyMaterials.Add(studyMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudyMaterial(StudyMaterial studyMaterial, Guid lectureId)
        {
            var lecture = await _context.Lectures.FirstOrDefaultAsync(l => l.LectureId == lectureId);
            if (lecture == null)
            {
                throw new ArgumentException($"Lecture with ID {lectureId} not found.");
            }

            lecture.StudyMaterialId = studyMaterial.StudyMaterialId;
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudyMaterial>> GetAllStudyMaterialsAsync()
        {
            return await _context.StudyMaterials.ToListAsync();
        }
    }
}
