using Education.Application.Abstractions;
using Education.Application.UseCases.WishListCases.Queries;
using Education.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.WishListCases.Handlers.QueryHandlers
{
    public class GetAllCoursesFromWishList : IRequestHandler<GetAllCourseFromWishListQuery, List<CourseModel>>
    {
        private readonly IEducationDbContext _context;

        public GetAllCoursesFromWishList(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseModel>> Handle(GetAllCourseFromWishListQuery request, CancellationToken cancellationToken)
        {
            var wishList = await _context.WishLists
                .Include(wl => wl.Courses)
                .FirstOrDefaultAsync(wl => wl.UserId == request.UserId);

            if (wishList == null)
            {
                return new List<CourseModel>();
            }

            return wishList.Courses.ToList();
        }
    }
}
