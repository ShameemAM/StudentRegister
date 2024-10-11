using Microsoft.AspNetCore.Mvc;
using StudentRegister.Application.Qualifications.Commands;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;
using StudentRegister.Domain.Entities;

namespace StudentRegister.API.Models
{
    public class StudentRegisterModel
    {
        public CreateStudent StudentModel { get; set; }
        public CreateQualification QualificationModel { get; set; }
        public List<CreateStudentHobbie> StudentHobbiesModel { get; set; }
    }
}
