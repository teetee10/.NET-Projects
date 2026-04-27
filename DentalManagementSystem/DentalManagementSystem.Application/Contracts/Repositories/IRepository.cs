using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Contracts.Repositories
{
    // The generic repository interface for CRUD operations on entities of type T.
    public interface IRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
