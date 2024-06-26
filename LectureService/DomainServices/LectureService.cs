using LectureService.Domain;
using LectureService.DomainServices.Interfaces;
using LectureService.Infrastructure;
using EventLibrary;
using MassTransit;

namespace LectureService.DomainServices
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IStudyMaterialRepository _studyMaterialRepository;
        private readonly IBusControl _serviceBus;

        public LectureService(ILectureRepository lectureRepository, IStudyMaterialRepository studyMaterialRepository, IBusControl serviceBus)
        {
            _lectureRepository = lectureRepository;
            _studyMaterialRepository = studyMaterialRepository;
            _serviceBus = serviceBus;
        }

        public async Task<Lecture> CreateLectureAsync(Lecture lecture)
        {
            var @event = new LectureCreated()
            {
                LectureId = Guid.NewGuid(),
                Location = lecture.Location,
                StartTime = lecture.StartTime,
                EndTime = lecture.EndTime,
                Teacher = lecture.Teacher
    };
            await _serviceBus.Publish(@event, context =>
            {
                context.SetRoutingKey("lecture.created");
            });

            lecture.LectureId = @event.LectureId;

            return lecture;
        }

        public Task<List<Lecture>> GetAllLecturesAsync()
        {
            return _lectureRepository.GetAllLecturesAsync();
        }

        public Task<Lecture> GetLectureByIdAsync(Guid lectureId)
        {
            var lecture = _lectureRepository.GetLectureById(lectureId);
            return lecture;
        }

        public Task<bool> DeleteLectureAsync(Guid lectureId)
        {
            var lecture = _lectureRepository.DeleteLectureAsync(lectureId);
            return lecture;
        }

        public async Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial, Guid lectureId)
        {
            var @event = new StudyMaterialCreated()
            {
                StudyMaterialId = Guid.NewGuid(),
                Content = studyMaterial.Content
            };
            await _serviceBus.Publish(@event, context =>
            {
                context.SetRoutingKey("studymaterial.created");
            });

            studyMaterial.StudyMaterialId = @event.StudyMaterialId;
            await _studyMaterialRepository.AddStudyMaterial(studyMaterial, lectureId);

            return studyMaterial;
        }

        public Task<List<StudyMaterial>> GetAllStudyMaterialsAsync()
        {
            return _studyMaterialRepository.GetAllStudyMaterialsAsync();
        }

        public Task<List<Class>> GetAllClassesAsync()
        {
            return _lectureRepository.GetAllClassesAsync();
        }

        public async Task AssignClassAsync(Guid classId, Guid lectureId)
        {
            await _lectureRepository.AssignClassAsync(classId, lectureId);
        }
    }
}
