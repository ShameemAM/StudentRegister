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
    public class UpdateStudentMapper : Profile
    {
        public UpdateStudentMapper()
        {
            CreateMap<UpdateStudent, StudentDetails>();
            CreateMap<StudentDetails, UpdateStudent>();
        }
    }
}
