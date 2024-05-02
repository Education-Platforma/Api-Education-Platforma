using Education.Application.Abstractions;
using Education.Application.UseCases.UserCases.Commands;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Education.Domain.Entities.Auth;

namespace Education.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateUserCommandHandler(IEducationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var file = request.Photo;
            string filePath = "";
            string fileName = "";
            if (file != null)
            {
                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "UserPhotos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch ()
                {
                    throw new Exception("Something went wrong ");
                }
            }
            var user = new UserModel()
            {
                FullName = request.FullName,
                Email = request.Email,
                PhotoPath = "/UserPhotos/" + fileName,
                PasswordHash = request.Password,
                Country = request.Counry,
            };
            var author = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel
            {
                Message = "Succesfully Created",
                StatusCode = 201,
                IsSuccess = true,
            };

        }
    }
}