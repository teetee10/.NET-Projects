using DentalManagementSystem.Application.Contracts.Repositories;
using DentalManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Persistence.Repositories
{
    public class DentalOfficeRepository : Repository<DentalOffice>, IDentalOfficeRepository
    {
        public DentalOfficeRepository(DentalManagementSystemDbContext context) : base(context)
        {
        }
    }
}
