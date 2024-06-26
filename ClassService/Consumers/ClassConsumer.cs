using MassTransit;
using EventLibrary;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace ClassService.Consumers
{
    public class ClassConsumer : IConsumer<ClassCreated>
    {
        private readonly IClassRepository _classRepository;

        public ClassConsumer(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task Consume(ConsumeContext<ClassCreated> context)
        {
            var @event = context.Message;
            var newClass = new Class();
            newClass.ApplyEvent(@event);

            await _classRepository.AddClass(newClass);

        }
    }
}