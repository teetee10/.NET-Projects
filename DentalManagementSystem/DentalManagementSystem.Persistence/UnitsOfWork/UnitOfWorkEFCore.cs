using DentalManagementSystem.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Persistence.UnitsOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly DentalManagementSystemDbContext _context;

        public UnitOfWorkEFCore(DentalManagementSystemDbContext context)
        {
            _context = context;
        }

        //public void Dispose() { }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
