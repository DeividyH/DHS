using DHS.Domain.Core.Interfaces.Audit;
using DHS.Domain.Core.Interfaces.Repositories;
using DHS.Infrastructure.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DHS.Infrastructure.Data.Repositories
{
   
    public class Repository<TEntity, TPrimaryKey> :
        IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly DhsDbContext _dhsDbContext;

        public Repository(DhsDbContext dhsDbContext)
        {
            _dhsDbContext = dhsDbContext;
        }

        #region Get a single entity

        public TEntity FirstOrDefault()
        {
            return _dhsDbContext.Set<TEntity>().FirstOrDefault();
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return _dhsDbContext.Set<TEntity>().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dhsDbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await _dhsDbContext.Set<TEntity>().FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await _dhsDbContext.Set<TEntity>().FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dhsDbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity Get(TPrimaryKey id)
        {
            return _dhsDbContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _dhsDbContext.Set<TEntity>().FindAsync(id);
        }

        #endregion

        #region Get a list of entities

        public IQueryable<TEntity> GetAll()
        {
            return GetAllIncluding();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = _dhsDbContext.Set<TEntity>().AsQueryable();

            if (propertySelectors != null)
            {
                foreach(var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }


        public List<TEntity> GetAllList()
        {
            return _dhsDbContext.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dhsDbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            var list = await _dhsDbContext.Set<TEntity>().ToListAsync();


            return list;
        }

        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dhsDbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        #endregion

        #region Insert

        public TEntity Insert(TEntity entity)
        {
            _dhsDbContext.Set<TEntity>().Add(entity);

            _dhsDbContext.SaveChanges();

            return entity;
        }

        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            _dhsDbContext.Set<TEntity>().Add(entity);

            _dhsDbContext.SaveChanges();

            return entity.Id;
        }

        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            await _dhsDbContext.Set<TEntity>().AddAsync(entity);

            await _dhsDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dhsDbContext.Set<TEntity>().AddAsync(entity);

            await _dhsDbContext.SaveChangesAsync();

            return entity;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            if (entity.Id != null)
            {
                _dhsDbContext.Set<TEntity>().Add(entity);

                _dhsDbContext.SaveChanges();
            }
            else
            {
                _dhsDbContext.Set<TEntity>().Update(entity);

                _dhsDbContext.SaveChangesAsync();

            }

            return entity;
        }

        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            entity = InsertOrUpdate(entity);

            return entity.Id;
        }
        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            if (entity.Id != null)
            {
                await _dhsDbContext.Set<TEntity>().AddAsync(entity);

                await _dhsDbContext.SaveChangesAsync();
            }
            else
            {
                _dhsDbContext.Set<TEntity>().Update(entity);

                await _dhsDbContext.SaveChangesAsync();

            }

            return entity;
        }

        public async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await InsertOrUpdateAsync(entity);

            return entity.Id;
        }

        #endregion

        #region Update 

        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);

            _dhsDbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);

            _dhsDbContext.Entry(entity).State = EntityState.Modified;

            return await Task.FromResult(entity);
        }

        #endregion

        #region Delete 

        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            _dhsDbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = GetFromChangeTrackerOrNull(id);
            if (entity != null)
            {
                Delete(entity);
                
                return;
            }

            entity = FirstOrDefault(id);
            if (entity != null)
            {
                Delete(entity);

                return;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            Delete(id);
        }
        
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
           foreach(var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
        }

        #endregion

        #region Others 

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion


        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _dhsDbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            _dhsDbContext.Set<TEntity>().Attach(entity);
        }

        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id)
        {
            var entry = _dhsDbContext.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, (ent.Entity as TEntity).Id)
                );

            return entry?.Entity as TEntity;
        }

        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}
