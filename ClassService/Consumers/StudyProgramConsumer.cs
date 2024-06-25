using MassTransit;
using EventLibrary;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace ClassService.Consumers
{
    public class StudyProgramConsumer : IConsumer<StudyProgramCreated>
    {
        private readonly IStudyProgramRepository _studyProgramRepository;

        public StudyProgramConsumer(IStudyProgramRepository studyProgramRepository)
        {
            _studyProgramRepository = studyProgramRepository;
        }
        public Task Consume(ConsumeContext<StudyProgramCreated> context)
        {
            var @event = context.Message;
            var studyProgram = new StudyProgram();

            studyProgram.ApplyEvent(@event);

            _studyProgramRepository.AddStudyProgram(studyProgram);

            return Task.CompletedTask;
        }
    }
}