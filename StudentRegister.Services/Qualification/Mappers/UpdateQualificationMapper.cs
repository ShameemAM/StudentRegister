using AutoMapper;
using StudentRegister.Application.Qualifications.Commands;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Qualifications.Mappers
{
    public class UpdateQualificationMapper : Profile
    {
        public UpdateQualificationMapper()
        {
            CreateMap<UpdateQualification, Qualification>();
            CreateMap<Qualification, UpdateQualification>();
        }
    }
}
