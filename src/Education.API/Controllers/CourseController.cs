using Education.Application.UseCases.CourseCases.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public CourseController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
        public async Task<List<CourseModel>> GetAllCourses()
        {
            var res = await _mediatr.Send(new GetAllCourseQuery());
            return res;
        }
    }
}