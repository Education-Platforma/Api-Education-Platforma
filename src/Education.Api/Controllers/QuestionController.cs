using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public QuestionController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public IActionResult CreateQuestion()
        {

            return Ok();
        }

    }
}
