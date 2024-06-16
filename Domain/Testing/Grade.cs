using Domain.Program;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Testing
{
    public class Grade
    {
        string Id { get; set; }
        Student Student { get; set; }
        Points Points { get; set; }
        Subject Subject { get; set; }
    }
}
