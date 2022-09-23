using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //protected DbSet<T> _ctx.Set<T>();
        protected DbContext _ctx;

        //public BaseRepository(DbContext dbContext)
        //{
        //    //_ctx.Set<T>() = dbContext.Set<T>();
        //    _ctx = dbContext;
        //}
        public BaseRepository()
        {
        }

        public void SetContext(DbContext CTX)
        {
            _ctx = CTX;
        }

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _ctx.Set<T>().AddRange(entities);
        }

        public int Count()
        {
            return _ctx.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _ctx.Set<T>().Count(criteria);
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _ctx.Set<T>().RemoveRange(entities);
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
            return _ctx.Set<T>().SingleOrDefault(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria)
        {
            return _ctx.Set<T>().Where(criteria).AsEnumerable<T>();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderByEnum.Ascending)
        {
            var q = _ctx.Set<T>().Where(criteria);

            if (orderBy != null)
            {
                if (orderByDirection.Equals(OrderByEnum.Ascending))
                {
                    q = q.OrderBy(orderBy);
                }
                else if (orderByDirection.Equals(OrderByEnum.Descending))
                {
                    q = q.OrderByDescending(orderBy);
                }
            }

            if (skip.HasValue)
                q = q.Take(skip.Value);

            if (take.HasValue)
                q = q.Take(take.Value);

            return q.AsEnumerable<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _ctx.Set<T>().AsEnumerable<T>();
        }

        public T GetById(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public T Edit(T entity)
        {
            //_ctx.Set<T>().Attach(entity);
            _ctx.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
