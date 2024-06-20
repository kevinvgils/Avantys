using MassTransit;

namespace EventLibrary
{
    [EntityName("TeacherCreated")]
    public class TeacherCreated
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid TeacherId { get; set; }
    }
}