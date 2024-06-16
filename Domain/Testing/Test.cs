using Domain.Program;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Testing
{
    public class Test
    {
        string Id { get; set; }
        Class Class { get; set; }
        Teacher Teacher { get; set; }
        Teacher Proctor { get; set; }
        Subject Subject { get; set; }
        Grade Grade { get; set; }

        public Test(string id, Class @class, Teacher teacher, Teacher proctor, Subject subject, Grade grade)
        {
            Id = id;
            Class = @class;
            Teacher = teacher;
            Proctor = proctor;
            Subject = subject;
            Grade = grade;
        }
    }
}
