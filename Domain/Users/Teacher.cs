using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class Teacher
    {
        string Id { get; set; }
        string Name { get; set; }

        TeacherRole Role { get; set; }

        public Teacher(string id, string name, TeacherRole role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }

    public enum TeacherRole
    {
        Teacher,
        Proctor,
    }
}
