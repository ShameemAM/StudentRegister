using AutoMapper;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Students.Mappers
{
    public class CreateStudentMapper : Profile
    {
        public CreateStudentMapper()
        {
            CreateMap<CreateStudent, StudentDetails>();
            CreateMap<StudentDetails, CreateStudent>();
        }
    }
}
