using MediatR;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Hobbie.Commands
{
    public class DeleteHobbie: IRequest
    {
        public int Id { get; set; }
    }
}
