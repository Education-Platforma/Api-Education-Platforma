using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCases.Commands
{
    public class CreateUserCommand : IRequest<ResponseModel>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IFormFile? Photo { get; set; }
        public string Counry { get; set; }
        public string phoneNumber {  get; set; }
    }
}