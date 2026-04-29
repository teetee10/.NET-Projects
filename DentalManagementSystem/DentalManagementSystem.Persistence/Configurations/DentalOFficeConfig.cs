using DentalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Persistence.Configurations
{
    internal class DentalOfficeConfig : IEntityTypeConfiguration<DentalOffice>
    {
        public void Configure(EntityTypeBuilder<DentalOffice> builder)
        {
            // Configure the DentalOffice entity here
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(150);
        }
    }
}
