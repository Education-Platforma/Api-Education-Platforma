using Education.Application.Abstractions;
using Education.Application.UseCases.LessonCase.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Handlers.CommandHandler
{
    public class UpdateLessonHandler : IRequestHandler<UpdateLessonCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public UpdateLessonHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (lesson == null)
            {
                return new ResponseModel()
                {
                    Message = "Lesson not found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }

            lesson.ExpForWatching = request.ExpForWatching;
            lesson.Title = request.Title;
            

            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Lesson updated",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
