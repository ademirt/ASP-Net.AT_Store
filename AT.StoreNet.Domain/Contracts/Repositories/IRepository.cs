using AT.StoreNet.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AT.StoreNet.Domain.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IEnumerable<T> Get();
        T Get(int id);

        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}