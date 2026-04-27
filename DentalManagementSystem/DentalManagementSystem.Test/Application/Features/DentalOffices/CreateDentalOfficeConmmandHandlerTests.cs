using DentalManagementSystem.Application.Contracts.Persistence;
using DentalManagementSystem.Application.Contracts.Repositories;
using DentalManagementSystem.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DentalManagementSystem.Domain.Entities;
using FluentValidation;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Tests.Application.Features.DentalOffices
{
    [TestClass]
    public class CreateDentalOfficeConmmandHandlerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository repository;
        private IUnitOfWork unitOfWork;
        private CreateDentalOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IDentalOfficeRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            var validator = Substitute.For<IValidator<CreateDentalOfficeCommand>>();
            handler = new CreateDentalOfficeCommandHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsGuid()
        {
            // Arrange
            var command = new CreateDentalOfficeCommand { Name = "Test Dental Office A" };
            //var dentalOfficeId = Guid.NewGuid();
            var dentalOffice = new DentalOffice("Dental Office A");
            repository.Add(Arg.Any<DentalOffice>()).Returns(dentalOffice);


            // Act
            var result = await handler.Handle(command);
            // Assert

            await repository.Received(1).Add(Arg.Any<DentalOffice>());
            await unitOfWork.Received(1).Commit();
            Assert.AreEqual(dentalOffice.Id, result);
        }

        [TestMethod]
        public async Task Handle_WhenThereisAnError_WeRollBack()
        {
            // Arrange
            var command = new CreateDentalOfficeCommand { Name = "Test Dental Office A" };
            repository.Add(Arg.Any<DentalOffice>()).Throws<Exception>();
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await handler.Handle(command);
            });

            await unitOfWork.Received(1).Rollback();

        }
    }
}
