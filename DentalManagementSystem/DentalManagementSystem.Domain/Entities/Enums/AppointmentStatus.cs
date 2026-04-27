using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.Entities.Enums
{
    // The AppointmentStatus enum represents the different statuses that an appointment can have in the dental management system. It has three values: Scheduled, Cancelled, and Completed. Each value is assigned a specific integer value starting from 1.
    public enum AppointmentStatus
    {
        Scheduled = 1,
        Cancelled = 2,
        Completed = 3
    }
}
