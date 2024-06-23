using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventlibrary
{
    public class Student
    {
        public Guid Id { get; set; }

        public Student(Guid id) => Id = id;
    }

    [EntityName("TestCreated")]
    public class Test
    {
        public Guid Id { get; set; }
        public string Module { get; set; }

        public Test(Guid id, string module)
        {
            Id = id;
            Module = module;
        }
    }
}
