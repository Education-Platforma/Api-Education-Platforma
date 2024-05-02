using Education.Application.Abstractions;
using Education.Application.UseCases.LessonCase.Commands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.LessonCase.Handlers.CommandHandler
{
    public class CreateLessonHandler : IRequestHandler<CreateLessonCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateLessonHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = new LessonModel()
            {
                CourseId = request.CourseId,
                ExpForWatching = request.ExpForWatching,
                Id = Guid.NewGuid(),
                VideoModelId = request.VideoModelId,
                Title = request.Title,
            };

            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Lesson created successfully",
                StatusCode = 200,
                IsSuccess = true
            };


        }
    }
}
