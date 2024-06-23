using MassTransit;
using ProgramService.Domain;
using ProgramService.DomainServices.Interfaces;
using EventLibrary;

namespace ProgramService.DomainServices
{
    public class StudyProgramService : IProgramService
    {
        private readonly IProgramRepository _repository;
        private readonly IBusControl _serviceBus;

        public StudyProgramService(IProgramRepository repository, IBusControl serviceBus)
        {
            _repository = repository;
            _serviceBus = serviceBus;
        }

        public async Task<StudyProgram> CreateProgram(StudyProgram program)
        {
            await _repository.CreateProgram(program);

            CreateProgram createdProgram = new CreateProgram();
            createdProgram.Id = program.Id;
            createdProgram.Modules = program.Modules;

            await _serviceBus.Publish(createdProgram);

            return program;
        }

        public IEnumerable<StudyProgram> GetAllPrograms()
        {
            throw new NotImplementedException();
        }
    }
}
