namespace TestService.Domain
{
    public class Test
    {
        public Guid Id { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? ProctorId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? GradeId { get; set; }

        public Test()
        {

        }
        public Test(Guid classId, Guid teacherId, Guid proctorId, Guid subjectId, Guid gradeId)
        {
            ClassId = classId;
            TeacherId = teacherId;
            ProctorId = proctorId;
            SubjectId = subjectId;
            GradeId = gradeId;
        }
    }
}
