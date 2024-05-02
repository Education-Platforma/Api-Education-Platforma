using Education.Application.Abstractions;
using Education.Application.UseCases.GroupCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.GroupCases.Handlers.QueryHandler
{
    public class GetGroupsByIdQueryHandler : IRequestHandler<GetGroupsByIdQuery, GroupModel>
    {
        private readonly IEducationDbContext _context;
        public GetGroupsByIdQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<GroupModel> Handle(GetGroupsByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(res == null)
            {
                return null;
            }
            return res;
        }
    }
}
