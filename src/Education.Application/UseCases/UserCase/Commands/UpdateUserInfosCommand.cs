using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCase.Commands
{
    public class UpdateUserInfosCommand : UserModel, IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
    }
}
