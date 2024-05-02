using Education.Application.Abstractions;
using Education.Application.UseCases.CouponCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.CouponCases.Handlers.CommandHandler
{
    public class DeleteCouponHandler : IRequestHandler<DeleteCouponCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public DeleteCouponHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(coupon == null)
            {
                return new ResponseModel { Message = "Coupon not found", IsSuccess = true, StatusCode = 404 };
            }

            return new ResponseModel { Message = "Coupon deleted", IsSuccess = true, StatusCode = 200 };

        }
    }
}
