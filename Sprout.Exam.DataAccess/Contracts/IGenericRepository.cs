using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);  
        Task<IReadOnlyList<T>> GetAllAsync(); 
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    }
}
