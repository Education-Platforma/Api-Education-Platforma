using Education.Application.Abstractions;
using Education.Application.UseCases.LessonCase.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Handlers.CommandHandler
{
    public class DeleteLessonHandler : IRequestHandler<DeleteLessonCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public DeleteLessonHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = _context.Lessons.FirstOrDefault(x => x.Id == request.Id);

            if(lesson == null)
            {
                return new ResponseModel()
                {
                    Message = "Lesson not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Lesson deleted",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
