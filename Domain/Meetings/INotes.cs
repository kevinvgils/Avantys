using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Meetings
{
    public interface INotes
    {
        string Id { get; set; }
        string Content { get; set; }
    }
}
