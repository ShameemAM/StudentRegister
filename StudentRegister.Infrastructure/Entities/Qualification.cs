using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Infrastructure.Entities
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public string ClassXBord { get; set; }
        public decimal ClassXPercentage { get; set; }
        public int ClassXYearOfPassing { get; set; }
        public string ClassXIIBord { get; set; }
        public decimal ClassXIIPercentage { get; set; }
        public int ClassXIIYearOfPassing { get; set; }
        public string GraduationBord { get; set; }
        public decimal GraduationPercentage { get; set; }
        public int GraduationYearOfPassing { get; set; }
        public string MastersBord { get; set; }
        public decimal MastersPercentage { get; set; }
        public int MastersYearOfPassing { get; set; }
        [ForeignKey(nameof(StudentId))]
        public StudentDetails StudentDetails { get; set; }
    }
}
