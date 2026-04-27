using Microsoft.VisualStudio.TestTools.UnitTesting;
using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Test.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        // Test that the constructor throws a BusinessRuleException if the email is null
        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            Assert.Throws<BusinessRuleException>(() => new Email(null!));
        }

        // Test that the constructor throws a BusinessRuleException if the email does not contain an '@' symbol
        [TestMethod]
        public void Constructor_EmailWithoutAt_Throws() 
        {
            Assert.Throws<BusinessRuleException>(() => new Email("tee.com"));
        }

        // Test that the constructor if the email is in a valid email format
        [TestMethod]
        public void Constructor_ValidEmail_NoExceptions()
        {
            new Email("tee@example.com");
        }

    }
}
