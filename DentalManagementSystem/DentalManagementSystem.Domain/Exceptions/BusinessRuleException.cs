using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.Exceptions
{
    // The BusinessRuleException class is a custom exception that is thrown when a business rule is violated. It inherits from the base Exception class and takes a message as a parameter that describes the business rule violation.
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message)
    : base(message)
        {

        }
    }
}
