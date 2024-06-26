using LectureService.Domain;
using LectureService.Models;
using EventLibrary;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using LectureService.DomainServices.Interfaces;
using static MassTransit.ValidationResultExtensions;

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

        [HttpGet]
        public async Task<ActionResult<List<Lecture>>> GetAllLectures()
        {
            var lectures = await _lectureService.GetAllLecturesAsync();
            return Ok(lectures);
        }

        [HttpGet("{lectureId}")]
        public async Task<ActionResult<Lecture>> GetLectureById(Guid lectureId)
        {
            var lecture = await _lectureService.GetLectureByIdAsync(lectureId);
            return Ok(lecture);
        }

        [HttpDelete("{lectureId}")]
        public async Task<IActionResult> DeleteLecture(Guid lectureId)
        {
            try
            {
                var deleted = await _lectureService.DeleteLectureAsync(lectureId);
                if (!deleted)
                {
                    return NotFound();
                }
                return NotFound(); // Status 404 Not Found als lecture niet gevonden is
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{lectureId}/create-studymaterial")]
        public async Task<IActionResult> CreateStudyMaterial([FromBody] StudyMaterialModel _studyMaterial, Guid lectureId)
        {
            try
            {
                var studyMaterial = new StudyMaterial();
                studyMaterial.Content = _studyMaterial.Content;
                var createdStudyMaterial = await _lectureService.CreateStudyMaterialAsync(studyMaterial, lectureId);

                return Ok(createdStudyMaterial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-studymaterials")]
        public async Task<ActionResult<List<Class>>> GetAllStudyMaterials()
        {
            var studymaterials = await _lectureService.GetAllStudyMaterialsAsync();
            return Ok(studymaterials);
        }

        [HttpGet("get-classes")]
        public async Task<ActionResult<List<Class>>> GetAllClasses()
        {
            var classes = await _lectureService.GetAllClassesAsync();
            return Ok(classes);
        }

        [HttpPost("{lectureId}/assign-class")]
        public async Task<IActionResult> AssignClass(Guid lectureId, [FromBody]AssignClassModel classId)
        {
            try
            {
                await _lectureService.AssignClassAsync(classId.Classid, lectureId);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
