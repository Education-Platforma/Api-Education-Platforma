using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Handlers.QueryHandlers
{
    public class GetAllVideosQueryHandler : IRequestHandler<Queries.GetAllVideosQuery, List<VideoModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllVideosQueryHandler(IEducationDbContext context) 
            => _context = context;

        public async Task<List<VideoModel>> Handle(Queries.GetAllVideosQuery request, CancellationToken cancellationToken)
        {
            return (await _context.Courses
                .FirstOrDefaultAsync(x => x.Id == request.CourseId))
                .Lessons.Select(x => x.VideoModel).ToList();
        }
    }
}
