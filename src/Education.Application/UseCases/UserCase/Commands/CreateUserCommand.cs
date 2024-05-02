using Education.Domain.Entities;
using Education.Domain.Entities.DemoModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.UserCase.Commands
{
    public class CreateUserCommand : IRequest<ResponseModel>
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTimeOffset JoinedData { get; set; } = DateTimeOffset.Now;
        //public Guid GroupModelId { get; set; }
        //public virtual GroupModel GroupModel { get; set; }
    }
}
