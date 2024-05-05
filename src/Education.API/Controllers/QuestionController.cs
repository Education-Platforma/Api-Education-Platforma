using Education.Application.UseCases.QuestionCase.Commands;
using Education.Application.UseCases.QuestionCase.Queries;
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
        public IActionResult CreateQuestion(CreateQuestionCommand command)
        {
            var result = _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionCommand command)
        {
            var result = _mediatr.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteQuestion(DeleteQuestionCommand command)
        {
            var result = _mediatr.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            var query = new GetAllQuestionsQuery();
            var result = _mediatr.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionById(Guid id)
        {
            var query = new GetQuestionByIdQuery { Id = id };
            var result = _mediatr.Send(query);
            return Ok(result);
        }

    }
}
