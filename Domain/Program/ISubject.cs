using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Testing;

namespace Domain.Program
{
    public interface ISubject
    {
        string Id { get; set; }
        string Name { get; set; }

        ICollection<ILecture> Lectures { get; set; }
        ICollection<IGrade> Grades { get; set; }
        ICollection<ITest> Tests { get; set; }
    }
}
