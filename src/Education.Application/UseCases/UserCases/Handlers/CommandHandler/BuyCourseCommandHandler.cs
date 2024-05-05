using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class BuyCourseCommandHandler : IRequestHandler<BuyCourseCommand, ResponseModel>
{
    private readonly IEducationDbContext _context;

    public BuyCourseCommandHandler(IEducationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel> Handle(BuyCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Find the user by UserId
            var user = await _context.Users
                .Include(u => u.Courses) // Include the Courses navigation property
                .FirstOrDefaultAsync(u => u.Id == request.UserId.ToString());

            if (user == null)
            {
                return new ResponseModel()
                {
                    Message = "User not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            // Check if the user already has the course
            if (user.Courses.Any(c => c.Id == request.CourseId))
            {
                return new ResponseModel()
                {
                    Message = "User already has the course",
                    StatusCode = 400,
                    IsSuccess = false
                };
            }

            // Find the course by CourseId
            var course = await _context.Courses
                .Include(c => c.Group) // Include the Group navigation property
                .FirstOrDefaultAsync(c => c.Id == request.CourseId);

            if (course == null)
            {
                return new ResponseModel()
                {
                    Message = "Course not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            // Add the course to the user's course list
            user.Courses.Add(course);

            // Add the user to the course's group
            course.Group.Students.Add(user);

            // Update the user and the course group
            _context.Users.Update(user);
            _context.Groups.Update(course.Group);
            await _context.SaveChangesAsync();

            return new ResponseModel()
            {
                Message = "Course added to user's course list and user added to the course group",
                StatusCode = 200,
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new ResponseModel()
            {
                Message = "Failed to add course to user's course list: " + ex.Message,
                StatusCode = 500,
                IsSuccess = false
            };
        }
    }
}
