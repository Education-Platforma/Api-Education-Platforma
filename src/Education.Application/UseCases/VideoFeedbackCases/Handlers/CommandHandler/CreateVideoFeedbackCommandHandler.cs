using Education.Application.Abstractions;
using Education.Application.UseCases.VideoFeedbackCases.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoFeedbackCases.Handlers.CommandHandler
{
    public class CreateVideoFeedbackCommandHandler : IRequestHandler<CreateVideoFeedbackCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public CreateVideoFeedbackCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateVideoFeedbackCommand request, CancellationToken cancellationToken)
        {
            var res = new VideoFeedbackModel()
            {
                Message = request.Message,
                UserId = request.UserId,
                VideoModellId = request.VideoModelId
            };
            await _context.VideoFeedbacks.AddAsync(res);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Succesfully created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
