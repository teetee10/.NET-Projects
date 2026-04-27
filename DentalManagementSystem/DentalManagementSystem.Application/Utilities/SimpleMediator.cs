using DentalManagementSystem.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Utilities
{
    // A simple implementation of the IMediator interface that uses reflection to find and invoke the appropriate request handlers and validators for a given request.
    public class SimpleMediator : IMediator
    {
        // The service provider used to resolve dependencies for request handlers and validators. Matches a request to its handler and validator based on the request type.
        private readonly IServiceProvider _serviceProvider;

        // Constructor that takes a service provider as a parameter and assigns it to the _serviceProvider field.
        public SimpleMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Method that takes a request of type IRequest<TResponse> and returns a response of type TResponse. It uses reflection to find and invoke the appropriate request handler and validator for the given request.
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            // Use reflection to find the appropriate validator for the request type and invoke it if it exists. If the validation fails, throw a CustomValidationException with the validation errors.
            var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
            var validator = _serviceProvider.GetService(validatorType);
            if (validator is not null)
            {
                // If a validator is found, invoke the ValidateAsync method and check the validation result. If the validation fails, throw a CustomValidationException with the validation errors.
                var validateMethod = validatorType.GetMethod("ValidateAsync");
                var taskToValidate = (Task)validateMethod!.Invoke(validator, new object[] { request, CancellationToken.None })!;
                await taskToValidate;

                var result = taskToValidate.GetType().GetProperty("Result");
                var validationResult = (ValidationResult)result!.GetValue(taskToValidate)!;

                if (!validationResult.IsValid)
                {
                    throw new CustomValidationException(validationResult);
                }
            }

            // Use reflection to find the appropriate request handler for the request type and invoke it. If no handler is found, throw a MediatorException.
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetService(handlerType);

            // If no handler is found, throw a MediatorException with a message indicating that the handler was not found for the request type.
            if (handler is null)
            {
                throw new MediatorExecption($"Handler not found for request type {request.GetType().Name}");
            }

            // If a handler is found, invoke the Handle method and return the result as a Task<TResponse>.
            var method = handlerType.GetMethod("Handle");
            return await (Task<TResponse>)method.Invoke(handler, new object[] { request })!;

        }
    }
}
