using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Qualifications.Commands
{
    public class DeleteQualification : IRequest
    {
        public int Id { get; set; }
    }
}
