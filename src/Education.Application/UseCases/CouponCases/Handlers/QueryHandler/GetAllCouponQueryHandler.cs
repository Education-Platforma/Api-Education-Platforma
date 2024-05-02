﻿using Education.Application.Abstractions;
using Education.Application.UseCases.CouponCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCases.Handlers.QueryHandler
{
    public class GetAllCouponQueryHandler : IRequestHandler<GetAllCouponQuery, List<CouponModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllCouponQueryHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CouponModel>> Handle(GetAllCouponQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Coupons.ToListAsync();

            if(result == null || result.Count==0)
            {
                return null!;
            }

            return result;
        }
    }
}
