using Education.Application.UseCases.LessonCase.Commands;
using Education.Application.UseCases.LessonCase.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public LessonController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<List<LessonModel>> GetAllLessons(Guid courseId)
        {
           return await _mediatr.Send(new GetAllLessonsQuery() { CourseId =courseId });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateLesson([FromForm] CreateLessonCommand command)
        {
            return await _mediatr.Send(command);
        }
    }
}
