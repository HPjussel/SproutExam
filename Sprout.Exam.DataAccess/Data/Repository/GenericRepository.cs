using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Contracts;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext cntxt)
        {
            _dbContext = cntxt;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (!entity.GetType().IsSubclassOf(typeof(DeleteableEntity)))
            {
                throw new ArgumentException("Deletion works only for DeletableEntity types", "entity");
            }

            var _softDeletableEntity = entity as DeleteableEntity;
            _softDeletableEntity.IsDeleted = true; 

            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(CancellationToken.None);

        }
    }
}
