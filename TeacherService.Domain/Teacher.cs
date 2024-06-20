using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherService.Domain
{
    public class Teacher
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Teacher(string name, string email)
        {

            Name = name;
            Email = email;


        }
    }
}
