using EventLibrary;
using MassTransit;
using ProgressService.DomainServices.Interfaces;

namespace ProgressService.Consumer
{
    public class ProgramCreatedConsumer
    {
        public class StudyProgramCreatedConsumer : IConsumer<StudyProgram>
        {
            private readonly IProgramRepository _StudyProgramRepository;

            public StudyProgramCreatedConsumer(IProgramRepository StudyProgramRepository)
            {
                _StudyProgramRepository = StudyProgramRepository;
            }

            public Task Consume(ConsumeContext<StudyProgram> context)
            {
                StudyProgram StudyProgram = new StudyProgram();
                _StudyProgramRepository.CreateProgram(StudyProgram);

                Console.WriteLine("CONSUME StudyProgram");

                return Task.CompletedTask;
            }
        }
    }
}
