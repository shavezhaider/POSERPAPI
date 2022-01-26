using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T GetByID(object id);
        Task<IEnumerable<T>> GetAll();
        void DisposeConnection();
        void CloseConnection();
        Task<T> GetByIdAsync<Tkey>(Tkey id);
        Task<T> FirstAsync(Expression<Func<T, bool>> filter);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);

        #region DML
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entity);

        Task<int> SaveChangesAsync();
        void Commit();

        void Rollback();

        void BeginTransaction();
        void DisposeTransaction();
        #endregion 

    }
}
