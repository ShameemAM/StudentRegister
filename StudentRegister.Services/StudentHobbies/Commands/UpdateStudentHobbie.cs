using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.ModelBinder;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.StudentHobbie.Commands
{
    [ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class UpdateStudentHobbie : IRequest<StudentHobbies>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Hobbie { get; set; }
    }
}
