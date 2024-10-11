using MediatR;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.StudentHobbie.Queries
{
    public class GetStudentHobbiesByStudentId : IRequest<List<StudentHobbies>>
    {
        public int StudentId { get; set; }
    }
}
