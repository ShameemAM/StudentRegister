using MediatR;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Qualifications.Commands
{
    public class UpdateQualification : IRequest<Qualification>
    {
        public int Id { get; set; }
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
