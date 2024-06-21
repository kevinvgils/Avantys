using System.ComponentModel.DataAnnotations;

namespace TestService.Domain
{
    public class Test
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime TestDate { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? ProctorId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? GradeId { get; set; }

        public Test()
        {

        }
        public Test(DateTime testDate, Guid classId, Guid teacherId, Guid proctorId, Guid subjectId, Guid gradeId)
        {
            TestDate = testDate;
            ClassId = classId;
            TeacherId = teacherId;
            ProctorId = proctorId;
            SubjectId = subjectId;
            GradeId = gradeId;
        }
    }
}
