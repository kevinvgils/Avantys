namespace Domain.Users
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? PaymentAuthId { get; set; }
        public Guid ApplicantId { get; set; }
        public string StudyProgram {  get; set; }


        public Student(string name, Guid applicantId, string studyProgram, string email)
        {
            Name = name;
            ApplicantId = applicantId;
            StudyProgram = studyProgram;
            Email = email;
        }
    }
}