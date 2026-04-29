using DentalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Persistence
{
    public class DentalManagementSystemDbContext : DbContext
    {
        public DentalManagementSystemDbContext(DbContextOptions<DentalManagementSystemDbContext> options)
            : base(options)
        {
        }

        protected DentalManagementSystemDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and constraints here if needed
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DentalManagementSystemDbContext).Assembly);
        }

        public DbSet<DentalOffice> DentalOffices { get; set; }
        //public DbSet<Patient> Patients { get; set; } 
        
        //public DbSet<Appointment> Appointments { get; set; }
        //public DbSet<Dentist> Dentists { get; set; }
    }
}
