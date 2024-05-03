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

        [HttpGet]
        public async Task<IActionResult> GetUserActivity(GetUserActivityQuery query)
        {
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetallUsersActivity(GetAllUsersActivityQuery query)
        {
            var result = await _mediatr.Send(query);
            return Ok(result);
        }


    }
}
