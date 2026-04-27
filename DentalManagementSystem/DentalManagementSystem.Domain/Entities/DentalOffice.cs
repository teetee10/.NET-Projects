using DentalManagementSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.Entities
{
    public class DentalOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        // Constructor that takes a name and validates that it is not null or empty
        public DentalOffice(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }

            Name = name;
            Id = Guid.CreateVersion7();
        }
    }
}
