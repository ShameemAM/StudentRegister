using Microsoft.EntityFrameworkCore;
using StudentRegister.Application.Abstraction;
using StudentRegister.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }
        public void AddData(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<List<T>> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return await query.ToListAsync();
        }

        public async Task<T> GetSingleValue(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            query = query.AsNoTracking().Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public void RemoveData(T entity)
        {
            _dbSet.Remove(entity);
        }

    }
}
