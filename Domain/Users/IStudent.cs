namespace Domain.Users
{
    public interface IStudent
    {
        string Id { get; set; }
        string Name { get; set; }
        string PaymentAuthId { get; set; }
        string AcceptanceId { get; set; }
    }
}