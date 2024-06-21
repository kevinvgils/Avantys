using System.ComponentModel.DataAnnotations;

namespace TestService.Domain
{
    public class Test
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime TestDate { get; set; }
        public string Module {  get; set; }

        public Guid? TeacherId { get; set; }
        public Guid? ProctorId { get; set; }

        public int? Grade { get; set; }
        public int? StudyPoints { get; set; }

        public Test()
        {

        }
        public Test(string module, DateTime testDate, Guid teacherId, Guid proctorId)
        {
            Id = Guid.NewGuid();
            TestDate = testDate;
            TeacherId = teacherId;
            ProctorId = proctorId;
            Module = module;
        }
    }
}
