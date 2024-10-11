using MediatR;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Hobbie.Queries
{
    public class GetAllHobbies : IRequest<List<Hobbies>>
    {
    }
}
