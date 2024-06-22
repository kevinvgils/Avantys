using ApplyService.Domain;
using ApplyService.DomainServices;
using ApplyService.DomainServices.Interfaces;
using EventLibrary;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApplyService.Infrastructure
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
            var eventStore = new EventStore
            {
                Id = Guid.NewGuid(),
                AggregateId = (@event as ApplicantCreated).ApplicantId.ToString(),  // Example for Applicant
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
