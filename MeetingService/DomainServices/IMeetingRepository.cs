using MeetingService.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingService.DomainServices
{
    public interface IMeetingRepository
    {
        Task<IEnumerable<Meeting>> GetAllMeetings();
        Task<Meeting> GetMeetingById(int id);
        Task AddMeeting(Meeting meeting);
        Task UpdateMeeting(Meeting meeting);
        Task DeleteMeeting(int id);
    }
}
