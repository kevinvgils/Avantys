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
        public Task Consume(ConsumeContext<ClassCreated> context)
        {
            var @event = context.Message;
            var newClass = new Class();

            newClass.ApplyEvent(@event);

            _classRepository.AddClass(newClass);

            return Task.CompletedTask;
        }
    }
}