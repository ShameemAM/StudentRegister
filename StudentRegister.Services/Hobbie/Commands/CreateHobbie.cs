using MediatR;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Hobbie.Commands
{
    public class CreateHobbie: IRequest<Hobbies>
    {
        public string Hobbie { get; set; }
    }
}
