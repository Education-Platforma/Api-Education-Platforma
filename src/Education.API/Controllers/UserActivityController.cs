using Education.Application.UseCases.UserActivityCase.Commands;
using Education.Application.UseCases.UserActivityCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserActivityController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserActivity(Guid id)
        {
            var query = new GetUserActivityQuery { Id = id };
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsersActivity()
        {
            var query = new GetAllUsersActivityQuery();
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserActivity(CreateUserActivityCommand command)
        {
            var result = await _mediatr.Send(command); 
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserActivity(UpdateUserActivityCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserActivity(DeleteUserActivityCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }


    }
}
