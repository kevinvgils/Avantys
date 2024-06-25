using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureService.Domain
{
    public interface ILectureEvent
    {
        public Guid LectureId { get; set; }
    }
}
