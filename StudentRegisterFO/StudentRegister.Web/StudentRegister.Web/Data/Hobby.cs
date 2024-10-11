using System.ComponentModel.DataAnnotations;

namespace StudentRegister.Web.Data
{
    public class Hobbies
    {
        public int Id { get; set; }
        [Required]
        public string Hobbie { get; set; }
        public int StudentId { get; set; }
    }
}
