using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Program
{
    public class StudyMaterial
    {
        string Id { get; set; }
        Lecture Lecture { get; set; }
        string Content { get; set; }

        public StudyMaterial(string id, Lecture lecture, string content)
        {
            Id = id;
            Lecture = lecture;
            Content = content;
        }
    }
}
