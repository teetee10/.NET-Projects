using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Utilities
{
    // The generic request handler interface for handling requests of type TRequest and returning responses of type TResponse. This is a common pattern in CQRS (Command Query Responsibility Segregation) architectures, where commands and queries are handled separately.
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
