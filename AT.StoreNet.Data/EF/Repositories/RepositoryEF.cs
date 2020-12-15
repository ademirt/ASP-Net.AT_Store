using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AT.StoreNet.Data.EF.Repositories
{
    public class RepositoryEF<T> : IRepository<T> where T : Entity
    {
        protected readonly ATStoreDataContextEF _db;

        public RepositoryEF(ATStoreDataContextEF db)
        {
            _db = db;
        }

        public IEnumerable<T> Get()
        {
            return _db.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Edit(T entity)
        {
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        private void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}