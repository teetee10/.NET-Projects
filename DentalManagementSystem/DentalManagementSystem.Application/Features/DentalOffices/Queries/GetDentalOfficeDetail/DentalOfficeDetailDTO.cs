using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class DentalOfficeDetailDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
