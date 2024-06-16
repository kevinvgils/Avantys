using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Program
{
    public class Program
    {
        string Id { get; set; }
        string Name { get; set; }
        ICollection<Class> Classes { get; set; }

        public Program(string id, string name, ICollection<Class> classes)
        {
            Id = id;
            Name = name;
            Classes = classes;
        }
    }
}
