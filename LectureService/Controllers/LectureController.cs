using LectureService.Domain;
using LectureService.Models;
using EventLibrary;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using LectureService.DomainServices.Interfaces;

namespace LectureService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectureController : ControllerBase
    {
        private readonly IBus _IBus;
        private readonly ILectureService _lectureService;

        public LectureController(IBus bus, ILectureService lectureService)
        {
            _IBus = bus;
            _lectureService = lectureService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLecture(LectureModel _lecture)
        {
            try
            {
                var lecture = new Lecture();
                lecture.Location = _lecture.Location;
                lecture.StartTime = _lecture.StartTime;
                lecture.EndTime = _lecture.EndTime;
                lecture.Teacher = _lecture.Teacher;
                var createdLecture = await _lectureService.CreateLectureAsync(lecture);

                return Ok(createdLecture);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{lectureId}/create-studymaterial")]
        public async Task<IActionResult> CreateStudyMaterial(StudyMaterialModel _studyMaterial, Guid lectureId)
        {
            try
            {
                var studyMaterial = new StudyMaterial();
                studyMaterial.Content = studyMaterial.Content;
                var createdStudyMaterial = await _lectureService.CreateStudyMaterialAsync(studyMaterial, lectureId);

                return Ok(createdStudyMaterial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Lecture>>> GetAllLectures()
        {
            var lectures = await _lectureService.GetAllLecturesAsync();
            return Ok(lectures);
        }

        [HttpPost("assign-class")]
        public async Task<IActionResult> AssignClass(Guid classId, Guid lectureId)
        {
            try
            {
                await _lectureService.AddClass(classId, lectureId);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
