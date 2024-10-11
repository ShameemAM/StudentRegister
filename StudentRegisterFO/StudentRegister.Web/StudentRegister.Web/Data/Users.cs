using System.ComponentModel.DataAnnotations;

namespace StudentRegister.Web.Data
{
    public class Users
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
