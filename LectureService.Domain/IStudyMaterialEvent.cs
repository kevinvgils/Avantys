using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureService.Domain
{
    public interface IStudyMaterialEvent
    {
        public Guid StudyMaterialId { get; set; }
    }
}
