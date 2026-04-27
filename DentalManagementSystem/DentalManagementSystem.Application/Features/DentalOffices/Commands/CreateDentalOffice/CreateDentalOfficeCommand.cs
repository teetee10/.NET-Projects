using DentalManagementSystem.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    // The command for creating a new dental office, which implements IRequest with a return type of Guid (the ID of the created dental office).
    public class CreateDentalOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
