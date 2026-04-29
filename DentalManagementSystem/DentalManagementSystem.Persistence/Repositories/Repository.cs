using DentalManagementSystem.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DentalManagementSystemDbContext _context;

        public Repository(DentalManagementSystemDbContext context)
        {
            _context = context;
        }


        public Task<T> Add(T entity)
        {
            _context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task Delete(T entity)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task Update(T entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
