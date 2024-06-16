using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Testing;
using Domain.Users;

namespace Domain.Program
{
    public interface IClass
    {
        string Id { get; set; }
        string Name { get; set; }
        IProgram Program { get; set; }
        ICollection<IStudent> Students { get; set; }
        ICollection<ITest> Tests { get; set; }
        ICollection<ILecture> Lectures { get; set; }
    }
}
