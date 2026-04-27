using DentalManagementSystem.Domain.Entities;
using DentalManagementSystem.Domain.Entities.Enums;
using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Test.Domain.Entities
{
    // Unit tests for the Appointment entity
    [TestClass]
    public class AppointmentTests
    {
        // Test data for the tests
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();
        private TimeInterval _interval = new TimeInterval(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        // Test that the constructor initializes the properties correctly and sets the status to Scheduled
        [TestMethod]
        public void Constructor_ValidAppointment_StatusIsScheduled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentistId);
            Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
            Assert.AreEqual(_interval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        // Test that the constructor throws a BusinessRuleException if the start time of the appointment is in the past
        [TestMethod]
        public void Constructor_StartTimeInThePast_Throws()
        {
            var interval = new TimeInterval(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            Assert.Throws<BusinessRuleException>(() => new Appointment(_patientId, _dentistId, _dentalOfficeId, interval));
        }

        // Test that the constructor throws a BusinessRuleException if the Appointment Status is changed to "Cancelled" 
        [TestMethod]
        public void Cancel_CancellingAppointment_ChangesStatusToCancelled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Cancel();
            Assert.AreEqual(AppointmentStatus.Cancelled, appointment.Status);
        }

        // Test that the constructor throws a BusinessRuleException if the Appointment is already cancelled and we try to cancel it again.
        [TestMethod]
        public void Cancel_CancellingAppointment_ThrowsIfStatusIsNotScheduled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Cancel();
            Assert.Throws<BusinessRuleException>(() => appointment.Cancel());
        }

        // Test that the constructor throws a BusinessRuleException if the Appointment Status is changed to "Completed"
        [TestMethod]
        public void Complete_CompletingAppointment_ChangesStatusToCompleted()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Complete();
            Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
        }

        // Test that the constructor throws a BusinessRuleException if the Appointment is already cancelled and then we try to complete it again.
        [TestMethod]
        public void Complete_CompletingAppointment_ThrowsIfStatutsIsNotScheduled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _interval);
            appointment.Cancel();
            Assert.Throws<BusinessRuleException>(() => appointment.Complete());
        } 
    }
}