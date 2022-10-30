using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable <T> GetAll();
        T Get(Guid Id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
        bool ItemExists(Guid Id);
    }
}
