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
    internal class CoursesRepository : Repository<Courses>, ICoursesRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CoursesRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateData(Courses entity)
        {
            _dbContext.Courses.Update(entity);
        }
    }
}
