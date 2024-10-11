using StudentRegister.Application.Abstraction;
using StudentRegister.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
       
        public ICoursesRepository CoursesRepository { get; private set; }

        public IHobbiesRepository HobbiesRepository { get; private set; }

        public IQualificationRepository QualificationRepository { get; private set; }

        public IStudentDetailsRepository StudentDetailsRepository { get; private set; }

        public IStudentHobbiesRepository StudentHobbiesRepository { get; private set; }

        public IUsersRepository UsersRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            CoursesRepository= new CoursesRepository(_dbContext);
            HobbiesRepository= new HobbiesRepository(_dbContext);
            QualificationRepository= new QualificationRepository(_dbContext);
            StudentDetailsRepository= new StudentDetailsRepository(_dbContext);
            StudentHobbiesRepository= new StudentHobbiesRepository(dBContext);
            UsersRepository= new UserRepository(_dbContext);
        }
        public Task SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
