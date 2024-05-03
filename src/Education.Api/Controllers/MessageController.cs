using Education.Application.UseCases.MessageCases.Command;
using Education.Application.UseCases.MessageCases.Queries;
using Education.Domain.Entities.DemoModels;
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

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMessages()
        {
            var query = new GetAllMessagesQuery(); 
            var result = await _mediator.Send(query); 
            return Ok(result);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetMessageById(Guid id)
        {
            var query = new GetMessageByIdQuery { Id = id }; 
            var result = await _mediator.Send(query); 
            return Ok(result);
        }
        [HttpPost]
        public async Task<ResponseModel> CreateMessage(CreateMessageCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateMessage(UpdateMessageCommand command)
        {
            return await _mediator.Send(command);
           
        }

        [HttpDelete]
        public async Task<ResponseModel> DeleteMessage(DeleteMessageCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
