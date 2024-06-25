using LectureService.Domain;
using LectureService.DomainServices;
using LectureService.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LectureService.Infrastructure
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreDbContext _context;

        public EventStoreRepository(EventStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<DomainEvent>> GetAllEventsAsync()
        {
            // Retrieve events from the database, sorted by OccurredOn in descending order
            var events = await _context.EventStores
                .OrderByDescending(e => e.OccurredOn)
                .ToListAsync();

            // Deserialize events and return as List<DomainEvent>
            var domainEvents = events.Select(e =>
                JsonConvert.DeserializeObject<DomainEvent>(e.Data)).ToList();

            return domainEvents;
        }

        public async Task SaveEventAsync(DomainEvent @event)
        {
            if (!(@event is ILectureEvent lectureEvent))
            {
                throw new ArgumentException("Event does not implement ILectureEvent", nameof(@event));
            }

            var eventStore = new EventStore
            {
                Id = Guid.NewGuid(),
                AggregateId = lectureEvent.LectureId.ToString(),
                AggregateType = @event.GetType().Name,
                EventType = @event.GetType().Name,
                Data = JsonConvert.SerializeObject(@event),  // Use JSON serialization
                OccurredOn = @event.OccurredOn
            };

            _context.EventStores.Add(eventStore);
            await _context.SaveChangesAsync();
        }
    }
}
