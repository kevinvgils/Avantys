using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class Acceptance
    {
        string Id { get; set; }
        Student Student { get; set; }

        public Acceptance(string id, Student student)
        {
            Id = id;
            Student = student;
        }
    }
}
