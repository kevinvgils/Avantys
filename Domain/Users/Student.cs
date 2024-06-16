namespace Domain.Users
{
    public class Student
    {
        string Id { get; set; }
        string Name { get; set; }
        string PaymentAuthId { get; set; }
        string AcceptanceId { get; set; }


        public Student(string id, string name, string paymentAuthId, string acceptanceId)
        {
            Id = id;
            Name = name;
            PaymentAuthId = paymentAuthId;
            AcceptanceId = acceptanceId;
        }
    }
}