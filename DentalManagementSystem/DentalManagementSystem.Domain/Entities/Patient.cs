using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
       
        public Email Email { get; private set; } = null!;

        // Constructor that takes a name and an email and validates that they are not null or empty
        public Patient(string name, Email email)
        {
            // Validate that the name is not null or empty
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }

            // Validate that the email is not null
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
