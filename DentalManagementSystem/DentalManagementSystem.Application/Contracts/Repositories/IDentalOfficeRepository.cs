using DentalManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Contracts.Repositories
{
    // The repository interface for managing dental office entities, which extends the generic IRepository interface with the DentalOffice type.
    public interface IDentalOfficeRepository : IRepository<DentalOffice>
    {
    }
}
