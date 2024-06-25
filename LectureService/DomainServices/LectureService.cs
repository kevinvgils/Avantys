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
        private readonly IEventStoreRepository _eventStore;
        private readonly IBusControl _serviceBus;

        public LectureService(ILectureRepository lectureRepository, IStudyMaterialRepository studyMaterialRepository, IEventStoreRepository eventStore, IBusControl serviceBus)
        {
            _lectureRepository = lectureRepository;
            _studyMaterialRepository = studyMaterialRepository;
            _eventStore = eventStore;
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
            await _eventStore.SaveEventAsync(@event);
            await _serviceBus.Publish(@event);

            lecture.LectureId = @event.LectureId;

            return lecture;
        }

        public async Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial)
        {
            var @event = new StudyMaterialCreated()
            {
                StudyMaterialId = Guid.NewGuid(),
                Content = studyMaterial.Content
            };
            await _eventStore.SaveEventAsync(@event);
            await _serviceBus.Publish(@event);

            studyMaterial.StudyMaterialId = @event.StudyMaterialId;

            return studyMaterial;
        }

        public Task<Lecture> GetLectureByIdAsync(Guid id)
        {
            var lecture = _lectureRepository.GetLectureById(id);
            return lecture;
        }
        public Task<List<Lecture>> GetAllLecturesAsync()
        {
            return _lectureRepository.GetAllLecturesAsync();
        }

        public async Task AddClass(Guid classId, Guid lectureId)
        {
            _lectureRepository.AddClass(classId, lectureId);
        }

        public async Task AddStudyMaterial(StudyMaterial studyMaterial, Guid lectureId)
        {
            _studyMaterialRepository.AddStudyMaterial(studyMaterial, lectureId);
        }
    }
}
