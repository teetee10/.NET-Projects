using DentalManagementSystem.Application.Contracts.Repositories;
using DentalManagementSystem.Application.Exceptions;
using DentalManagementSystem.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DentalManagementSystem.Application.Utilities;
using DentalManagementSystem.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Tests.Application.Features.DentalOffices
{
    [TestClass]
    public class GetDentalOfficeDetailQueryHandlerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IDentalOfficeRepository _repository;
        private GetDentalOfficeDetailQueryHandler _handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IDentalOfficeRepository>();
            _handler = new GetDentalOfficeDetailQueryHandler(_repository);
        }
        [TestMethod]
        public async Task Handle_DentalOfficeExistsReturnsIt()
        {
            // Arrange
            //var dentalOffice = Guid.NewGuid();


            var dentalOffice = new DentalOffice("Test Dental Office A");
            var id = dentalOffice.Id;
            var query = new GetDentalOfficeDetailQuery { Id = id };

            _repository.GetById(id).Returns(dentalOffice);


            // Act
            var result = await _handler.Handle(query);

            // Assert
            Assert.IsNotNull(result);

            Assert.AreEqual(id, result.Id);
            Assert.AreEqual("Test Dental Office A", result.Name);
        }

        [TestMethod]
        public async Task Handle_DentalOfficeDoesNotExists_Throws()
        {
                // Arrange
                var id = Guid.NewGuid();
                var query = new GetDentalOfficeDetailQuery { Id = id };
                _repository.GetById(id).ReturnsNull();
                await Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query));
        }

    }
}
