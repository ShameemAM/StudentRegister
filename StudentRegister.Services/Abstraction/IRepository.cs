using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Application.Abstraction
{
    public interface IRepository<T> where T : class 
    {
        Task<List<T>> GetAll();
        Task<T> GetSingleValue(Expression<Func<T, bool>> filter);
        void AddData(T entity);
        void RemoveData(T entity);
    }
}
