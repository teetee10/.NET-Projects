using DentalManagementSystem.Domain.Entities.Enums;
using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; }

        public TimeInterval TimeInterval { get; private set; }
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        // Constructor that takes a patient id, a dentist id, a dental office id, and a time interval and validates that the time interval is not in the past
        public Appointment(Guid patientId, Guid dentistId, Guid dentalOfficeId, TimeInterval timeInterval)
        {
            if (timeInterval.Start < DateTime.UtcNow)
            {
                throw new BusinessRuleException($"The start time cannot be in the past");
            }

            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            TimeInterval = timeInterval;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();

        }

        // Method to cancel the appointment that validates that the appointment is not already cancelled or completed
        public void Cancel()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be cancelled");
            }

            Status = AppointmentStatus.Cancelled;
        }

        // Method to complete the appointment that validates that the appointment is not already cancelled or completed
        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled appointments can be completed");
            }

            Status = AppointmentStatus.Completed;
        }
    }
}
