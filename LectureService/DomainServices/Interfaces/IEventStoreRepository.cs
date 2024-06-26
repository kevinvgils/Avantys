using LectureService.Domain;

namespace LectureService.DomainServices.Interfaces
{
    public interface IEventStoreRepository
    {
        Task SaveEventAsync(DomainEvent @event);

        Task<List<DomainEvent>> GetAllEventsAsync();
    }
}
