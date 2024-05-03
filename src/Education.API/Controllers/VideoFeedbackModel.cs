using Education.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoFeedbackModel : ControllerBase
    {
        private readonly IMediator _mediatr;
        public VideoFeedbackModel(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<List<VideoFeedbackModel>> GetAllFeedbacks(Guid VideoId)
        {
            throw new NotImplementedException();
        }
    }
}
