using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using WebScience.UnitOfWork.Interface;

namespace WebScience.UnitOfWork.Repository
{
    internal class GenericRepository<T> : RepositoryBase, IGenericRepository<T> where T : class
    {
        public GenericRepository(IDbTransaction transaction) : base(transaction) { }

        public T Get(int id)
        {
            return Connection.Get<T>(id);
        }

        public T Get(string id)
        {
            return Connection.Get<T>(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Connection.GetAsync<T>(id);
        }

        public async Task<T> GetAsync(string id)
        {
            return await Connection.GetAsync<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Connection.GetAll<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsyn()
        {
            return await Connection.GetAllAsync<T>();
        }

        private bool Prosess(long result)
        {
            if (result > 0) return true; else return false;
        }

        public bool Add(T t)
        {
            var result = Connection.Insert<T>(t);
            return Prosess(result);
        }

        public async Task<bool> AddAsyn(T t)
        {
            var result = await Connection.InsertAsync<T>(t);
            return Prosess(result);
        }

        public bool Update(T t)
        {
            if (t == null) { return Prosess(0); }
            return Connection.Update<T>(t);
        }

        public async Task<bool> UpdateAsyn(T t)
        {
            if (t == null) { return Prosess(0); }
            return await Connection.UpdateAsync<T>(t);
        }

        public bool Delete(T entity)
        {
            return Connection.Delete<T>(entity);
        }

        public async Task<bool> DeleteAsyn(T entity)
        {
            return await Connection.DeleteAsync<T>(entity);
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

      

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ReloadEntity(T t)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }



        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}