using AutoMapper;
using StudentRegister.Application.Hobbie.Commands;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Course.Mappers
{
    public class UpdateHobbieMapper: Profile
    {
        public UpdateHobbieMapper()
        {
            CreateMap<UpdateHobbie, Hobbies>();
        }
    }
}
