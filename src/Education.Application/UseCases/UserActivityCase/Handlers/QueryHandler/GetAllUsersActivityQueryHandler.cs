using Education.Application.Abstractions;
using Education.Application.UseCases.UserActivityCase.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserActivityCase.Handlers.QueryHandler
{
    public class GetAllUsersActivityQueryHandler : IRequestHandler<GetAllUsersActivityQuery, List<UserActivityModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllUsersActivityQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserActivityModel>> Handle(GetAllUsersActivityQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.UserActivityModels.ToListAsync();
            if(result == null || result.Count == 0)
            {
                return null!;
            }

            return result;
        }
    }
}
