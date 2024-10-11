using StudentRegister.Application.Abstraction;
using StudentRegister.DataAccess;
using StudentRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Infrastructure.Repositories
{
    public class StudentDetailsRepository : Repository<StudentDetails>, IStudentDetailsRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public StudentDetailsRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateData(StudentDetails studentDetails)
        {
            _dbContext.StudentDetails.Update(studentDetails);
        }
    }
}
