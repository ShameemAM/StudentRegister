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
    public class UserRepository : IUsersRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRepository(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void AddUser(Users user)
        {
            _dbContext.Users.Add(user);
        }

        public async Task<Users> GetUsers(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u=>u.Email == email);
        }
    }
}
