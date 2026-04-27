using DentalManagementSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; } = null!;

        // Constructor that takes an email string and validates that it is not null or empty and that it contains an '@' symbol
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException($"The {nameof(email)} is required");
            }

            if (!email.Contains("@"))
            {
                throw new BusinessRuleException($"The {nameof(email)} is not valid");
            }

            Value = email;

        }
    }
}
