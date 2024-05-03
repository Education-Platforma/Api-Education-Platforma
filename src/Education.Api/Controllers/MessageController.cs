using Education.Application.UseCases.MessageCases.Command;
using Education.Application.UseCases.MessageCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(DeleteMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("all")] // Route path: api/Message/all
        public async Task<IActionResult> GetAllMessages()
        {
            var query = new GetAllMessagesQuery(); // Create query instance
            var result = await _mediator.Send(query); // Send query
            return Ok(result);
        }

        [HttpGet("{id}")] // Route path: api/Message/{id}
        public async Task<IActionResult> GetMessageById(Guid id)
        {
            var query = new GetMessageByIdQuery { Id = id }; // Create query instance with id
            var result = await _mediator.Send(query); // Send query
            return Ok(result);
        }
    }
}
