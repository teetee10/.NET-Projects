using DentalManagementSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        // Constructor that takes a start and end time and validates that the start time is not after the end time
        public TimeInterval(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new BusinessRuleException("The start time cannot be after the end time");
            }

            Start = start;
            End = end;
        }
    }
}
