using AutoMapper;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.StudentHobbie.Mappers
{
    public class UpdateStudentHobbieMapper : Profile
    {
        public UpdateStudentHobbieMapper()
        {
            CreateMap<UpdateStudentHobbie, StudentHobbies>();
            CreateMap<StudentHobbies, UpdateStudentHobbie>();
        }
    }
}
