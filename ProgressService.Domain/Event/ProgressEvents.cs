using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressService.Domain.Event
{
    public class ProgressEvents
    {
        public class Student
        {
            public Guid Id { get; set; }

            public Student(Guid id) => Id = id;
        }

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
}
