using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Testing;

namespace Domain.Program
{
    public class Subject
    {
        string Id { get; set; }
        string Name { get; set; }

        ICollection<Lecture> Lectures { get; set; }
        ICollection<Grade> Grades { get; set; }
        ICollection<Test> Tests { get; set; }

        public Subject(string id, string name, ICollection<Lecture> lectures, ICollection<Grade> grades, ICollection<Test> tests)
        {
            Id = id;
            Name = name;
            Lectures = lectures;
            Grades = grades;
            Tests = tests;
        }
    }
}
