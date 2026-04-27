using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.Entities
{
    public class Dentist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        // Constructor that takes a name and an email and validates that they are not null or empty
        public Dentist(string name, Email email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }

            if (email is null)
            {
                throw new BusinessRuleException($"The {nameof(email)} is required");
            }

            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }
    }
}
