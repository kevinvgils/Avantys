using LectureService.Domain;
using LectureService.DomainServices;
using LectureService.Models;
using EventLibrary;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace LectureService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectureController : ControllerBase
    {
        private readonly IBus _IBus;
        private readonly ILectureRepository _lectureRepository;
        private readonly IStudyMaterialRepository _studyMaterialRepository;

        public LectureController(IBus bus, ILectureRepository lectureRepository, IStudyMaterialRepository studyMaterialRepository)
        {
            _IBus = bus;
            _lectureRepository = lectureRepository;
            _studyMaterialRepository = studyMaterialRepository;
        }

        [HttpPost("schedule-teacher")]
        public async Task<IActionResult> ScheduleTeacher(Guid teacherId, Guid lectureId, DateTime startTime, DateTime endTime)
        {
            try
            {
                await _lectureRepository.AddTeacher(teacherId, lectureId);
                var lecture = await _lectureRepository.GetLectureById(lectureId);
                if (lecture == null)
                {
                    return NotFound("Lecture not found");
                }

                lecture.StartTime = startTime;
                lecture.EndTime = endTime;
                await _lectureRepository.UpdateLecture(lecture);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("assign-class")]
        public async Task<IActionResult> AssignClass(Guid classId, Guid lectureId)
        {
            try
            {
                await _lectureRepository.AddClass(classId, lectureId);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("add-study-material")]
        public async Task<IActionResult> AddStudyMaterial(Guid lectureId, StudyMaterial studyMaterial)
        {
            try
            {
               await _studyMaterialRepository.AddStudyMaterial(studyMaterial, lectureId);
               
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
