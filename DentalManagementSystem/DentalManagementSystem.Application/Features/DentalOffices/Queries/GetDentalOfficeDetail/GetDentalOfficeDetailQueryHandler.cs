using DentalManagementSystem.Application.Contracts.Repositories;
using DentalManagementSystem.Application.Exceptions;
using DentalManagementSystem.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class GetDentalOfficeDetailQueryHandler : IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;

        public GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository dentalOfficeRepository)    
        {
            _dentalOfficeRepository = dentalOfficeRepository;
        }

        public async Task<DentalOfficeDetailDTO> Handle(GetDentalOfficeDetailQuery request)
        {
            var dentalOffice = await _dentalOfficeRepository.GetById(request.Id);

            if (dentalOffice == null)
            {
                throw new NotFoundException();
            }
            
            return dentalOffice.MapToDentalOfficeDetailDTO();

        }
    }
}
