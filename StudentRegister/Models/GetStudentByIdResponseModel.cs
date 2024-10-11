using StudentRegister.Domain.Entities;

namespace StudentRegister.API.Models
{
    public class GetStudentByIdResponseModel
    {
        public StudentDetails StudentModel { get; set; }
        public Courses CourseModel { get; set; }
        public List<StudentHobbies> StudentHobbiesModel { get; set; }
        public Qualification QualificationModel { get; set; }
    }
}
