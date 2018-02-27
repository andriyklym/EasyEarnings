using System;
using System.Collections.Generic;
using System.Linq;
using EasyEarnings.Contracts;
using System.Data.Entity;
using System.Linq.Expressions;

namespace EasyEarnings.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        #region Constructor

        public Repository(Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #endregion

        #region Contract methods

        public void Add(T entity)
        {
            if (entity != null)
                _dbSet.Add(entity);
            else throw new ArgumentNullException();
        }

        public void Delete(Guid? id)
        {
            if (id != null)
            {
                var entityToDelete = _dbSet.Find(id);
                Delete(entityToDelete);
            }
            else throw new ArgumentNullException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, object>> include)
        {
            return _dbSet.Include(include).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, object>> include1, Expression<Func<T, object>> include2)
        {
            return _dbSet.Include(include1).Include(include2).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> include)
        {
            return _dbSet.Where(where).Include(include).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> include1, Expression<Func<T, object>> include2)
        {
            return _dbSet.Where(where).Include(include1).Include(include2).ToList();
        }

        public T GetById(Guid? id)
        {
            return id != null ? _dbSet.Find(id) : null;
        }

        public int GetCount(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).Count();
        }

        public T GetElement(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else throw new ArgumentNullException();
        }

        #endregion

        #region Private method

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entityToDelete">entity to delete</param>
        private void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        #endregion
    }
}
