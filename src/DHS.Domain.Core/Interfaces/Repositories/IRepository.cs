using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DHS.Domain.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> :
            IRepository<TEntity, int> where TEntity : class
    {
    }

    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        #region Get a single entity

        TEntity Get(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        TEntity FirstOrDefault();
        TEntity FirstOrDefault(TPrimaryKey id);
        Task<TEntity> FirstOrDefaultAsync();
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Get a list of entities 

        List<TEntity> GetAllList();
        Task<List<TEntity>> GetAllListAsync();
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        #endregion

        #region Insert 

        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        TPrimaryKey InsertAndGetId(TEntity entity);
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity);
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        #endregion

        #region Update 

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        #endregion

        #region Delete 

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Others 

        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        long LongCount();
        Task<long> LongCountAsync();
        long LongCount(Expression<Func<TEntity, bool>> predicate);
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
