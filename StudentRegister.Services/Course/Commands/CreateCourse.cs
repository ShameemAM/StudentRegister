using MediatR;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Course.Commands
{
    public class CreateCourse: IRequest<Courses>
    {
        public string CourseName { get; set; }
    }
}
