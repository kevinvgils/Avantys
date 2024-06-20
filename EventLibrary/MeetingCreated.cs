using MassTransit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLibrary
{
    [EntityName("MeetingCreated")]
    public class MeetingCreated
    {
        public Guid MeetingId { get; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? StudentId { get; set; }
       
    }
}
