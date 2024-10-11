using Microsoft.EntityFrameworkCore;
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
    public class StudentHobbiesRepository : Repository<StudentHobbies>, IStudentHobbiesRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public StudentHobbiesRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateData(StudentHobbies entity)
        {
            _dbContext.StudentHobbies.Update(entity);
        }
        public async Task<List<StudentHobbies>> GetHobbiesByStudentId(int studentId)
        {
            return _dbContext.StudentHobbies.Where(sh=>sh.StudentId == studentId).ToList();
        }
    }
}
