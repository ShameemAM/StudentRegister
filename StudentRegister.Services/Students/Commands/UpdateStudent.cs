using MediatR;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Students.Commands
{
    public class UpdateStudent  : IRequest<StudentDetails>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int CourseId { get; set; }
    }
}
