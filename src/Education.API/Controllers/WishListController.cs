using Education.Application.UseCases.WishListCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishListController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> AddToWishList(string userId, Guid courseId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            if (courseId == Guid.Empty)
            {
                return BadRequest("Course ID cannot be empty.");
            }

            var response = await _mediator.Send(new AddToWishListCommand { UserId = userId, CourseId = courseId });

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFromWishList(string userId, Guid courseId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            if (courseId == Guid.Empty)
            {
                return BadRequest("Course ID cannot be empty.");
            }

            var response = await _mediator.Send(new DeleteFromWishList() { UserId = userId, CourseId = courseId });

            return Ok(response);
        }
    }
}
