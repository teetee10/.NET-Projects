using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Contracts.Persistence
{
    // The Unit of Work interface for managing transactions across multiple repositories. It provides methods to commit or rollback changes made to the data store.
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
