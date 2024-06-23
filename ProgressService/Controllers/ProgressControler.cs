using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProgressService.Domain;
using ProgressService.DomainServices.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace ProgressService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _ProgressRepository;


        public ProgressController(IProgressRepository ProgressRepository)
        {
            _ProgressRepository = ProgressRepository;

        }

        [HttpGet]
        public IEnumerable<Progress> GetProgress()
        {
            return _ProgressRepository.getAllProgress();
        }

        [HttpGet("{ProgressId}")]
        public Progress GetProgress(string ProgressId)
        {
            return _ProgressRepository.getProgress(new Guid(ProgressId));
        }

        [HttpPut("{ProgressId}/Grade")]
        public void GradeProgress(string ProgressId, Progress progress)
        {
            progress.Id = new Guid(ProgressId);
            _ProgressRepository.gradeProgress(progress);
        }
    }
}