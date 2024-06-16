using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface ITeacher
    {
        string Id { get; set; }
        string Name { get; set; }

        TeacherRole Role { get; set; }
    }

    public enum TeacherRole
    {
        Teacher,
        Proctor,
    }
}
