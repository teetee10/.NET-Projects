using DentalManagementSystem.Domain.Entities;
using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Test.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        //  Test that the constructor throws a BusinessRuleException if the name is null
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            Assert.Throws<BusinessRuleException>(() => new DentalOffice(null!));
        }
    }
}
