using System.ComponentModel.DataAnnotations;

namespace StudentRegister.Web.Data
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
    }
}
