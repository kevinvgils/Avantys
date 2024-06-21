using LectureService.Domain;
using LectureService.DomainServices;
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
            var lecture = await _context.Lectures.FirstOrDefaultAsync(l => l.Id == lectureId);
            if (lecture == null)
            {
                throw new ArgumentException($"Lecture with ID {lectureId} not found.");
            }

            lecture.StudyMaterialId = studyMaterial.Id;
            _context.Lectures.Update(lecture);
            await _context.SaveChangesAsync();
        }

        public async Task<StudyMaterial> GetStudyMaterialById(Guid studyMaterialId)
        {
            return await _context.StudyMaterials.FirstOrDefaultAsync(l => l.Id == studyMaterialId);
        }
    }
}
