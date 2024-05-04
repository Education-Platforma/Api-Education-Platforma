using Education.Application.Abstractions;
using Education.Application.UseCases.WishListCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.WishListCases.Handlers.CommandHandlers
{
    public class DeleteFromWishlistCommandHandler : IRequestHandler<DeleteFromWishList, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public DeleteFromWishlistCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteFromWishList request, CancellationToken cancellationToken)
        {
            try
            {
                var userWishList = await _context.WishLists.FirstOrDefaultAsync(w => w.UserId == request.UserId);

                if (userWishList == null)
                {
                    return new ResponseModel
                    {
                        Message = "User's wishlist not found",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                var courseToRemove = userWishList.Courses.FirstOrDefault(c => c.Id == request.CourseId);

                if (courseToRemove == null)
                {
                    return new ResponseModel
                    {
                        Message = "Course not found in the user's wishlist",
                        StatusCode = 404,
                        IsSuccess = false
                    };
                }

                userWishList.Courses.Remove(courseToRemove);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    Message = "Course deleted from wishlist successfully",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    Message = $"Failed to delete course from wishlist: {ex.Message}",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
