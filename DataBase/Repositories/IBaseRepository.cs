using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void SetContext(DbContext CTX);
        //DbContext _ctx { get; }

        T GetById(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> criteria);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderByEnum.Ascending);


        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        T Edit(T entity);

        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        int Count();
        int Count(Expression<Func<T, bool>> criteria);

        //void Submit();
    }

    public static class OrderByEnum
    {
        public const string Ascending = "ASC";
        public const string Descending = "DESC";
    }
}
