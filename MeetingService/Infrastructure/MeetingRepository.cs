using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingService.Domain;
using MeetingService.DomainServices;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly MeetingDbContext _context;

        public MeetingRepository(MeetingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meeting>> GetAllMeetings()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<Meeting> GetMeetingById(int id)
        {
            return await _context.Meetings.FindAsync(id);
        }

        public async Task AddMeeting(Meeting meeting)
        {
            await _context.Meetings.AddAsync(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMeeting(Meeting meeting)
        {
            _context.Meetings.Update(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMeeting(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
                await _context.SaveChangesAsync();
            }
        }
    }
}
