using System.ComponentModel.DataAnnotations;

namespace StudentRegister.Web.Data
{
    public class Student
    {
        public Student() 
        {
            StudentModel = new();
            CourseModel = new();
            StudentHobbiesModel = new();
            QualificationModel = new();
        }
        [ValidateComplexType]
        public StudentDetails? StudentModel { get; set; }
        [ValidateComplexType]
        public Courses? CourseModel { get; set; }
        [ValidateComplexType]
        public List<Hobbies>? StudentHobbiesModel { get; set; }
        [ValidateComplexType]
        public Qualification? QualificationModel { get; set; }
    }
    public class StudentDetails
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(50)]
        public string EmailId { get; set; }
        [MaxLength(10)]
        public string MobileNumber { get; set; }
        [Required]
        public int Gender { get; set; }
        public string Address { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        public int PinCode { get; set; }
        [MaxLength(30)]
        public string State { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public int CourseId { get; set; }
    }
    public class Qualification
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public string? ClassXBord { get; set; }
        public decimal? ClassXPercentage { get; set; }
        public int? ClassXYearOfPassing { get; set; }
        public string? ClassXIIBord { get; set; }
        public decimal? ClassXIIPercentage { get; set; }
        public int? ClassXIIYearOfPassing { get; set; }
        public string? GraduationBord { get; set; }
        public decimal? GraduationPercentage { get; set; }
        public int? GraduationYearOfPassing { get; set; }
        public string? MastersBord { get; set; }
        public decimal? MastersPercentage { get; set; }
        public int? MastersYearOfPassing { get; set; }
    }
}
