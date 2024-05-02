using Education.Application.Abstractions;
using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCase.Handlers
{
    public class CreateUserHandler : IRequestHandler<UserModel, ResponseModel>
    {
        private readonly IEducationDbContext _context;

        public CreateUserHandler(IEducationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UserModel request, CancellationToken cancellationToken)
        {
            if(request is not null)
            {
                var user = new UserModel()
                {
                    FullName = request.FullName,
                    Name = request.Name,
                    Country = request.Country,
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return new ResponseModel()
                {
                    Message = "User created successfully",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            return new ResponseModel()
            {
                Message = "User not created",
                StatusCode = 400,
                IsSuccess = false
            };
        }
    }
}
