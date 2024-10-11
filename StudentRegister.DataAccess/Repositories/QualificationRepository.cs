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
    public class QualificationRepository : Repository<Qualification>, IQualificationRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public QualificationRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateData(Qualification entity)
        {
            _dbContext.Qualifications.Update(entity);
        }
    }
}
