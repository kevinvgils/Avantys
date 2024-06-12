using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Program
{
    public interface ILecture
    {
        string Id { get; set; }
        IClass Class { get; set; }
        ITeacher Teacher { get; set; }
        ICollection<IStudyMaterial> StudyMaterials { get; set; }
    }
}
