using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Utilities
{
    // The mediator interface for sending requests and receiving responses. It defines a method Send that takes an IRequest and returns a Task of the response type.
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
