using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Program
{
    public interface IProgram
    {
        string Id { get; set; }
        string Name { get; set; }
        ICollection<IClass> Classes { get; set; }
    }
}
