using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using System.Collections.Immutable;

namespace Infrastructure
{
    public class ProgressRepository : IProgressRepository
    {

        private readonly ProgressDbContext _context;

        public ProgressRepository(ProgressDbContext context)
        {
            _context = context;
        }


        public async Task<Progress> createProgress(Progress progress)
        {
            await _context.Progress.AddAsync(progress);
            return progress;
        }

        public IEnumerable<Progress> getAllProgress()
        {
            return _context.Progress.ToImmutableArray();
        }

        public Progress getProgress(Guid id)
        {
            return _context.Progress.SingleOrDefault(x => x.Id == id);
        }

        public async Task gradeProgress(Progress progress)
        {
            Progress? progressToGrade = _context.Progress.SingleOrDefault(x => x.Id == progress.Id);

            if (progressToGrade != null)
            {
                progressToGrade.Grade = progress.Grade;
                progressToGrade.StudyPoints = progress.StudyPoints;
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the progress with the specified ID is not found.
                throw new Exception("Progress not found");
            }
        }
    }
}
