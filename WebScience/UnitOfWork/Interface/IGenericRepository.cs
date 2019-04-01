using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace WebScience.UnitOfWork.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        T Get(string id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsyn();
        Task<T> GetAsync(int id);
        Task<T> GetAsync(string id);
        bool Add(T t);
        Task<bool> AddAsyn(T t);
        bool Update(T t);
        Task<bool> UpdateAsyn(T t);
        bool Delete(T entity);
        Task<bool> DeleteAsyn(T entity);

        int Count();
        Task<int> CountAsync();

        void Dispose();
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);
        void ReloadEntity(T t);
        void Save();
        Task<int> SaveAsync();

    }
}