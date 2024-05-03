using Education.Application.UseCases.CategoryCases.Commands;
using Education.Application.UseCases.CategoryCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CategoryController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            var result = await _mediatr.Send(command);  
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(GetAllCategoryQuery query)
        {
            var result = await _mediatr.Send(query);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetCategory(GetCategoryByIdQuery query)
        {
            var result = await _mediatr.Send(query);
            return Ok(result);
        }




    }
}
