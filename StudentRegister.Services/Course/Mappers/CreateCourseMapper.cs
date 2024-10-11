using AutoMapper;
using StudentRegister.Application.Course.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Course.Mappers
{
    public class CreateCourseMapper : Profile
    {
        public CreateCourseMapper()
        {
            CreateMap<CreateCourse, Courses>();
        }
    }
}
