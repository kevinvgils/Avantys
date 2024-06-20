using DomainServices;
using ProgressService.Domain;
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

        public Task createProgress(Progress progress)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Progress> getAllProgress()
        {
            return _context.Progress.ToImmutableArray();
        }

        public Progress getProgress(Guid id)
        {
            return _context.Progress.SingleOrDefault(x => x.Id == id);
        }

        public Task gradeProgress(Progress progress)
        {
            throw new NotImplementedException();
        }
    }
}
