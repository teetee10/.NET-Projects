using DentalManagementSystem.Application.Contracts.Persistence;
using DentalManagementSystem.Application.Contracts.Repositories;
using DentalManagementSystem.Persistence.Repositories;
using DentalManagementSystem.Persistence.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Persistence
{
    public static class RegisterPersistenceServices
    {
        //public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)

        {
            services.AddDbContext<DentalManagementSystemDbContext>(options =>
                options.UseSqlServer("name=DentalManagementSystemConnectionString"));
            // Register repositories
            services.AddScoped<IDentalOfficeRepository, DentalOfficeRepository>();

            //services.AddScoped<IPatientRepository, PatientRepository>();
            //services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            //Register Unit of Work

           services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();
            return services;
        }
    }
}
