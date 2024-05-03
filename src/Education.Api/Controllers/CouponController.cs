using Education.Application.UseCases.CouponCase.Commands;
using Education.Application.UseCases.CouponCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CouponController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(DeleteCouponCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCoupons(GetAllCouponQuery query)
        {
            var result = await _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCoupon(GetCouponByIdQuery query)
        {
            var result = await _mediatr.Send(query);
            return Ok(result);
        }











    }
}
