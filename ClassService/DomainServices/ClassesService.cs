using EventLibrary;
using MassTransit;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace DomainServices
{
    public class ClassesService : IClassService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IBusControl _serviceBus;


        public ClassesService(IStudentRepository repo, IBusControl serviceBus)
        {
            _studentRepository = repo;
            _serviceBus = serviceBus;
        }

        public async Task<Class> CreateClassAsync(Class @class)
        {
            var classCreated = new ClassCreated()
            {
                StudyProgramId = @class.StudyProgramId,
                ClassId = Guid.NewGuid(),
                ClassCode = @class.ClassCode,
            };

            await _serviceBus.Publish(classCreated, context =>
            {
                context.SetRoutingKey("class.created");
            });

            @class.ClassId = classCreated.ClassId;

            return @class;
        }
    }
}
