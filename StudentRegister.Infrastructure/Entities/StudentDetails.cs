using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Infrastructure.Entities
{
    public class StudentDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmailId { get; set; }
        public int MobileNumber { get; set; }
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
        [ForeignKey(nameof(CourseId))]
        public Courses Course { get; set; }
    }
}
