using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Program
{
    public interface IStudyMaterial
    {
        string Id { get; set; }
        ILecture Lecture { get; set; }
        string Content { get; set; }
    }
}
