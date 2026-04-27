using DentalManagementSystem.Domain.Entities;
using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Test.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {
        // Test that the constructor throws a BusinessRuleException if the name is null
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            var email = new Email("tee@example.com");
            Assert.Throws<BusinessRuleException>(() => new Patient(null!, email));
        }

        // Test that the constructor throws a BusinessRuleException if the email is null
        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            Assert.Throws<BusinessRuleException>(() => new Patient("tee", email: null!));
        }

        // Test that the constructor creates a Patient object when given valid name and email
        [TestMethod]
        public void Constructor_ValidPatient_NoExceptions()
        {
            var email = new Email("tee@example.com");
            new Patient("tee", email);
        }
    }
}
