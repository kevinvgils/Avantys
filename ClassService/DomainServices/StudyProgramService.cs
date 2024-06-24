using EventLibrary;
using MassTransit;
using ClassService.Domain;
using ClassService.DomainServices.Interfaces;

namespace DomainServices
{
    public class StudyProgramService : IStudyProgramService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IBusControl _serviceBus;


        public StudyProgramService(IStudentRepository repo, IBusControl serviceBus)
        {
            _studentRepository = repo;
            _serviceBus = serviceBus;
        }

        public async Task<StudyProgram> CreateStudyProgramAsync(StudyProgram studyProgram)
        {
            var studyProgramCreated = new StudyProgramCreated()
            {
                StudyProgramId = studyProgram.StudyProgramId,
                Subjects = studyProgram.Subjects,
                Name = studyProgram.Name,
            };

            await _serviceBus.Publish(studyProgramCreated);

            return studyProgram;
        }
    }
}
