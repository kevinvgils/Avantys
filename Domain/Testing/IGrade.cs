using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Testing
{
    public interface IGrade
    {
        string Id { get; set; }
        IStudent Student { get; set; }
        IPoints Points { get; set; }
        ISubject Subject { get; set; }
    }
}
