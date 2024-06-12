using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Testing
{
    public interface ITest
    {
        string Id { get; set; }
        IClass Class { get; set; }
        ITeacher Teacher { get; set; }
        ITeacher Proctor { get; set; }
        ISubject Subject { get; set; }
        IGrade Grade { get; set; }
    }
}
