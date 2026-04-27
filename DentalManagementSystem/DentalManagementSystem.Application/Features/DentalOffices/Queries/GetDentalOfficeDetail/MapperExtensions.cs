using DentalManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    internal static class MapperExtensions
    {
        public static DentalOfficeDetailDTO MapToDentalOfficeDetailDTO(this DentalOffice dentalOffice)
        {
            var dto = new DentalOfficeDetailDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };

            return dto;
        }
    }
}
