using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.Entities;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Test.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        // Test that the constructor throws a BusinessRuleException if the name is null
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            var email = new Email("tee@example.com");
            Assert.Throws<BusinessRuleException>(() => new Dentist(null!, email));
        }

        // Test that the constructor throws a BusinessRuleException if the email is null
        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {  
            Assert.Throws<BusinessRuleException>(() => new Dentist("tee",  email: null!));            
        }

        // Test that the constructor creates a Dentist object when given valid name and email
        [TestMethod]
        public void Constructor_ValidDentist_NoExceptions()
        {
            var email = new Email("tee@example.com");
            new Dentist("tee", email);
        }
    }
}
