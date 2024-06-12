using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace Domain.Meetings
{
    public interface IMeeting
    {
        string Id { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        ITeacher Teacher { get; set; }
        IStudent Student { get; set; }
        INotes Notes { get; set; }
    }
}
