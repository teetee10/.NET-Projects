using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Test.Domain.ValueObjects
{
    // Tests for the TimeInterval value object
    [TestClass]
    public class TimeIntervalTests
    {
        // Test that the constructor throws an exception if the start time is after the end time
        [TestMethod]
        public void Constructor_StartTimeAfterEndTime_Throws()
        {
            Assert.Throws<BusinessRuleException>(() => new TimeInterval(DateTime.UtcNow.AddHours(2), DateTime.UtcNow.AddHours(1)));
        }

        // Test that the constructor does not throw an exception if the start time is before or equal to the end time
        [TestMethod]
        public void Constructor_ValidInterval_NoExceptions()
        { 
         new TimeInterval(DateTime.UtcNow.AddHours(1), DateTime.UtcNow.AddHours(1));
        }
    }
}
