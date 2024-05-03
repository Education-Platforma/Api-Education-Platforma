using Education.Application.UseCases.UserCases.Commands;
using Education.Application.UseCases.UserCases.Queries;
using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public UserController(IMediator mediator)
        {
            _mediatr = mediator;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<List<UserModel>> GetAllUsers()
        {
            var res = await _mediatr.Send(new GetAllUsersQuery());
            return res;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<UserModel> GetUserById(Guid id)
        {
            var res = await _mediatr.Send(new GetUserByIdQuery() { Id = id });
            return res;
        }
        [HttpPut ]
        public async Task<ResponseModel> UpdateUser([FromForm] UpdateUserCommand command)
        {
            var res = await _mediatr.Send(command);
            return res;
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteUser(Guid id)
        {
            var res = await _mediatr.Send( new DeleteUserCommand(){ Id = id});
            return res;
        }
        [HttpGet]
        public async Task<ResponseModel> BuyCourse()
        {
            throw new NotImplementedException();
        }

    }
}