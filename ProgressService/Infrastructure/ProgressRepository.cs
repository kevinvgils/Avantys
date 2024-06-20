using DomainServices;
using ProgressService.Domain;

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
            throw new NotImplementedException();
        }

        public Task gradeProgress(Progress progress)
        {
            throw new NotImplementedException();
        }
    }
}
