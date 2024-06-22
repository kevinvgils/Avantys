using ApplyService.Domain;

namespace ApplyService.DomainServices.Interfaces
{
    public interface IEventStoreRepository
    {
        Task SaveEventAsync(DomainEvent @event);

        Task<List<DomainEvent>> GetAllEventsAsync();
    }
}
