using Education.Application.UseCases.VideoCases.Command;
using Education.Application.UseCases.VideoCases.Handlers.QueryHandlers;
using Education.Application.UseCases.VideoCases.Queries;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public VideoController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<List<VideoModel>> GetAllVideos(Guid courseId)
        {
            return await _mediatr.Send(new GetAllVideosQuery() { CourseId = courseId });
        }
        [HttpPost]
        public async Task<ResponseModel> CreateVideo(CreateVideoCommand command)
        {
            var res = await _mediatr.Send(command);
            return new ResponseModel()
            {
                Message = "Seccesfully created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
