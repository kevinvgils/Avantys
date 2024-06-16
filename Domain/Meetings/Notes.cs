using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Meetings
{
    public class Notes
    {
        string Id { get; set; }
        string Content { get; set; }

        public Notes(string id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
