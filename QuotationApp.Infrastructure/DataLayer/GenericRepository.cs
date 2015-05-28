using QuotationApp.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotationApp.Infrastructure.DataLayer
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ApplicationDbContext _db;
        DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }
        public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            var entityToDelete = _db.Set<TEntity>().Find(id);
            _dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entity)
        {
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
