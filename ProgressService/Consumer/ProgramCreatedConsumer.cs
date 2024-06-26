using EventLibrary;
using MassTransit;
using ProgressService.DomainServices.Interfaces;

namespace ProgressService.Consumer
{
    public class ProgramCreatedConsumer
    {
        public class StudyProgramCreatedConsumer : IConsumer<StudyProgramCreated>
        {
            private readonly IProgramRepository _StudyProgramCreatedRepository;

            public StudyProgramCreatedConsumer(IProgramRepository StudyProgramCreatedRepository)
            {
                _StudyProgramCreatedRepository = StudyProgramCreatedRepository;
            }

            public Task Consume(ConsumeContext<StudyProgramCreated> context)
            {
                StudyProgramCreated StudyProgramCreated = new StudyProgramCreated() 
                {
                    StudyProgramId = context.Message.StudyProgramId,
                    Name = context.Message.Name,
                    Subjects = context.Message.Subjects
                };

                _StudyProgramCreatedRepository.CreateProgram(StudyProgramCreated);

                Console.WriteLine("CONSUME StudyProgramCreated");

                return Task.CompletedTask;
            }
        }
    }
}
