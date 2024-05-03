using Education.Application.Abstractions;
using Education.Application.UseCases.CourseCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CourseCases.Handlers.QueryHandlers
{
    public class GetCourseByTeacherNameQueryHandler : IRequestHandler<GetCourseByTeacherNameQuery, CourseModel>
    {
        private readonly IEducationDbContext _context;
        public GetCourseByTeacherNameQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<CourseModel> Handle(GetCourseByTeacherNameQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Courses.FirstOrDefaultAsync(x => x.TeacherName == request.TeacherName);
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}
