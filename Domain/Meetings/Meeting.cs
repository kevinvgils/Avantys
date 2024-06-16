using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;

namespace Domain.Meetings
{
    public class Meeting
    {
        string Id { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        Teacher Teacher { get; set; }
        Student Student { get; set; }
        Notes Notes { get; set; }

        public Meeting (string id, DateTime startTime, DateTime endTime, Teacher teacher, Student student, Notes notes)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Teacher = teacher;
            Student = student;
            Notes = notes;
        }
    }
}
