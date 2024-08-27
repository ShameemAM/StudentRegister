using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Infrastructure.Entities
{
    public class Hobbies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Hobbie { get; set; }
    }
}
