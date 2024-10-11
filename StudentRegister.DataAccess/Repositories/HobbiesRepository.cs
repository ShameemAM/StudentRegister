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
    public class HobbiesRepository : Repository<Hobbies>, IHobbiesRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public HobbiesRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateData(Hobbies entity)
        {
            _dbContext.Hobbies.Update(entity);
        }
    }
}
