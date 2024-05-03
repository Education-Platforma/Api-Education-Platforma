using Education.Application.Abstractions;
using Education.Application.UseCases.CourseCases.Cammands;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseCases.Handlers.CommandHandlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        public CreateCourseCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new CourseModel()
            {
                CourseName = request.CourseName,
                Description = request.Description,
                TotalTime = request.TotalTime,
                Price = request.Price,
                Language = request.Language,
                TeacherName = request.TeacherName,
                CouponId = request.CouponId,
                CategoryId = request.CategoryId,
            };
             _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return new ResponseModel()
            {
                Message = "Succesfully Created",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
