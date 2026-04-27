using DentalManagementSystem.Application.Exceptions;
using DentalManagementSystem.Application.Utilities;
using DentalManagementSystem.Domain.Exceptions;
using DentalManagementSystem.Domain.ValueObjects;
using FluentValidation;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DentalManagementSystem.Tests.Application.Utilities.Mediator
{

    [TestClass]
    public class SimpleMediatorTest
    {
        // A simple request class for testing
        public class FalseRequest : IRequest<string>
        {
               public required string Name { get; set; }
        }

        public class  FalseRequestValidator : AbstractValidator<FalseRequest>
        {
            public FalseRequestValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
             
        }

        // A simple validator for the FalseRequest
        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandleExecuted()
        {
            var request = new FalseRequest() { Name = "Test" };
            //var request = new FalseRequest();

            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProviderMock = Substitute.For<IServiceProvider>();

            serviceProviderMock.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(handlerMock);

            var mediator = new SimpleMediator(serviceProviderMock);

            var result = await mediator.Send(request);

            await handlerMock.Received(1).Handle(request);
        }

        [TestMethod]
        public async Task Send_WithoutRegisteredHandler_Throws()
        {
            var request = new FalseRequest() { Name = "Test" };

            var serviceProviderMock = Substitute.For<IServiceProvider>();

            // Configure service provider to return null for the handler
            serviceProviderMock.GetService(typeof(IRequestHandler<FalseRequest, string>)).ReturnsNull();

            var mediator = new SimpleMediator(serviceProviderMock);

            await Assert.ThrowsAsync<MediatorExecption>(async () => await mediator.Send(request));
        }

        [TestMethod]
        public async Task Send_InvalidCommand_Throws()
        {
            var request = new FalseRequest() { Name = "" };

            var serviceProviderMock = Substitute.For<IServiceProvider>();
            var validator = new FalseRequestValidator();
            serviceProviderMock.GetService(typeof(IValidator<FalseRequest>)).Returns(validator);
            var mediator = new SimpleMediator(serviceProviderMock);
            //var result = await mediator.Send(request);

            await Assert.ThrowsAsync<CustomValidationException>(async () => await mediator.Send(request));

        }
    }
}
