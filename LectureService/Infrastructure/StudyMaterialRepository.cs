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

        public async Task AddStudyMaterial(StudyMaterial studyMaterial, Guid lectureId)
        {
            var lecture = await _context.Lectures.FirstOrDefaultAsync(l => l.StudyMaterialId == lectureId);
            if (lecture == null)
            {
                throw new ArgumentException($"Lecture with ID {lectureId} not found.");
            }

            lecture.StudyMaterialId = studyMaterial.StudyMaterialId;
            await _context.SaveChangesAsync();
        }

        public async Task<StudyMaterial> GetStudyMaterialById(Guid studyMaterialId)
        {
            return await _context.StudyMaterials.FirstOrDefaultAsync(l => l.StudyMaterialId == studyMaterialId);
        }
    }
}
