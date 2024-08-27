using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegister.Infrastructure.Entities;

namespace StudentRegister.DataAccess
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<StudentHobbies> StudentHobbies { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
