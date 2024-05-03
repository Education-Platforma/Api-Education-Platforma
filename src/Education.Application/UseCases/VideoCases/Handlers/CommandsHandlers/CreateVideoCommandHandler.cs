using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Command;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Handlers.CommandsHandlers
{
    public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateVideoCommandHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ResponseModel> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, request.FolderName);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.FolderName);

            var path = Path.Combine(
                folderPath,
                fileName);

            if (!Directory.Exists(folderPath))
            {
                File.Create(folderPath);
            }

            try
            {
                using (var stream = File.OpenRead(path))
                {
                    await request.Video.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = "Something went wrong",
                    StatusCode = 404,
                    IsSuccess = false,
                };
            }
            var res = new VideoModel()
            {
                VideoPath = folderPath + fileName,
                FolderName = request.FolderName,
                Length = request.Video.Length.ToString()
            };
            return new ResponseModel()
            {
                Message = "Succesfully created",
                StatusCode = 201,
                IsSuccess = true,
            };

        }
    }
}