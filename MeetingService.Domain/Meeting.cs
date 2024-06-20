using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MeetingService.Domain
{
    public class Meeting
    {
      

        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? StudentId { get; set; }
        //public Notes Notes { get; set; }

        public Meeting (DateTime startTime, DateTime endTime)
        {
            
            StartTime = startTime;
            EndTime = endTime;
           
          
        }

    
    }
}
