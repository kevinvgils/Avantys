using EventLibrary;
using MassTransit;
using ProgressService.DomainServices.Interfaces;

namespace ProgressService.Consumer
{
    public class ProgramCreatedConsumer
    {
        public class StudyProgramCreatedCreatedConsumer : IConsumer<StudyProgramCreated>
        {
            private readonly IProgramRepository _StudyProgramCreatedRepository;

            public StudyProgramCreatedCreatedConsumer(IProgramRepository StudyProgramCreatedRepository)
            {
                _StudyProgramCreatedRepository = StudyProgramCreatedRepository;
            }

            public Task Consume(ConsumeContext<StudyProgramCreated> context)
            {
                StudyProgramCreated StudyProgramCreated = new StudyProgramCreated();
                _StudyProgramCreatedRepository.CreateProgram(StudyProgramCreated);

                Console.WriteLine("CONSUME StudyProgramCreated");

                return Task.CompletedTask;
            }
        }
    }
}
