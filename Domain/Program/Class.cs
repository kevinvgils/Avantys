using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Testing;
using Domain.Users;

namespace Domain.Program
{
    public class Class
    {
        string Id { get; set; }
        string Name { get; set; }
        Program Program { get; set; }
        ICollection<Student> Students { get; set; }
        ICollection<Lecture> Lectures { get; set; }

        public Class(string id, string name, Program program, ICollection<Student> students, ICollection<Lecture> lectures)
        {
            Id = id;
            Name = name;
            Program = program;
            Students = students;
            Lectures = lectures;
        }
    }
}
