using Microsoft.EntityFrameworkCore.Storage;

using POSERPAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POSERPAPI.Repository.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet;
        private IDbContextTransaction _transaction;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void CloseConnection()
        {
            //  _dbContext.Database.Connection.Close();
        }

        public void DisposeConnection()
        {
            _dbContext.Dispose();
        }

        public Task<T> FirstAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Task.Run(() => _dbSet.AsEnumerable());
        }

        public T GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync<Tkey>(Tkey id)
        {
            return await _dbSet.FindAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await Task.Run(() => _dbSet.Update(entity));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task UpdateRangeAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(T entity)
        {
            try
            {
                await Task.Run(() => _dbSet.Remove(entity));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveRangeAsync(IEnumerable<T> entity)
        {
            try
            {

                await Task.Run(() => _dbSet.RemoveRange(entity));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void DisposeTransaction()
        {
            throw new NotImplementedException();
        }


    }
}
