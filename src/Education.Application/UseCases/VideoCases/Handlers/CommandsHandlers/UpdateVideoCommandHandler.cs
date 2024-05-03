using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Command;
using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Handlers.CommandsHandlers
{
    public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpdateVideoCommandHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ResponseModel> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve the existing video by Id
                var existingVideo = await _context.Videos.FindAsync(request.Id);

                if (existingVideo == null)
                {
                    return new ResponseModel {  Message = "Video not found", StatusCode = 404,IsSuccess = false };
                }

                if (request.Video != null)
                {
                    var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, request.FolderName);
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Video.FileName);

                    var path = Path.Combine(folderPath, fileName);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await request.Video.CopyToAsync(stream);
                    }

                    existingVideo.VideoPath = Path.Combine(folderPath, fileName);
                }

                if (!string.IsNullOrWhiteSpace(request.FolderName))
                {
                    existingVideo.FolderName = request.FolderName;
                }

                // Optionally, save changes to the database
                await _context.SaveChangesAsync();

                return new ResponseModel { Message = "Video updated successfully", StatusCode = 200 ,IsSuccess = true};
            }
            catch (Exception ex)
            {
                return new ResponseModel { Message = "An error occurred: " + ex.Message, StatusCode = 500,IsSuccess = false };
            }
        }
    }
}
