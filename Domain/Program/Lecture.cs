using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Program
{
    public class Lecture
    {
        string Id { get; set; }
        Class Class { get; set; }
        Teacher Teacher { get; set; }
        ICollection<StudyMaterial> StudyMaterials { get; set; }

        public Lecture(string id, Class @class, Teacher teacher, ICollection<StudyMaterial> studyMaterials)
        {
            Id = id;
            Class = @class;
            Teacher = teacher;
            StudyMaterials = studyMaterials;
        }
    }
}
