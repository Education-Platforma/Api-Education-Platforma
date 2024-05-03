using Education.Application.Abstractions;
using Education.Application.UseCases.VideoCases.Command;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.UseCases.VideoCases.Handlers.CommandsHandlers
{
    public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, ResponseModel>
    {
        private readonly IEducationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DeleteVideoCommandHandler(IEducationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ResponseModel> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, request.FolderName, request.Id.ToString());

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);

                    
                    return new ResponseModel { IsSuccess = true, Message = "Video deleted successfully", StatusCode = 200 };
                }
                else
                {
                    return new ResponseModel { IsSuccess = false, Message = "Video not found", StatusCode = 404 };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel { IsSuccess = false, Message = "An error occurred: " + ex.Message, StatusCode = 500 };
            }
        }
    }
}
