using StudentRegister.Application.Course.Commands;
using StudentRegister.Application.Qualifications.Commands;
using StudentRegister.Application.StudentHobbie.Commands;
using StudentRegister.Application.Students.Commands;

namespace StudentRegister.API.Models
{
    public class StudentUpdateModel
    {
        public UpdateStudent StudentModel {  get; set; }
        public List<UpdateStudentHobbie> StudentHobbiesModel { get; set; }
        public UpdateQualification QualificationModel { get; set; }
    }
}
