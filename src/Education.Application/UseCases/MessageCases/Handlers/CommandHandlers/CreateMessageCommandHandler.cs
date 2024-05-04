using Education.Application.Abstractions;
using Education.Application.UseCases.MessageCases.Command;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Education.Application.UseCases.MessageCases.Handlers.CommandHandlers
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public CreateMessageCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var newMessage = new MessageModel
            {
                Id = Guid.NewGuid(),
                Message = request.Message,
                Date = DateTimeOffset.UtcNow,
                GroupId = request.GoupId,
                SenderId = request.SenderId.ToString() 
            };

            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                Message = "Succesfully Created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
