using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Utilities
{
    // The IRequest interface is a marker interface used to represent a request in the application. It is typically implemented by command and query classes in the CQRS pattern, where TResponse represents the type of response expected from handling the request.
    public interface IRequest<TResponse>
    {
    }
}
