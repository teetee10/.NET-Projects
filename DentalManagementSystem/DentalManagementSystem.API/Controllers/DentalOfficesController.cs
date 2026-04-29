using DentalManagementSystem.API.DTOs.DentalOffices;
using DentalManagementSystem.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DentalManagementSystem.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DentalManagementSystem.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagementSystem.API.Controllers
{
    // Controller for managing dental offices
    [ApiController]
    [Route("api/dentaloffices")]
    public class DentalOfficesController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor that takes an IMediator instance for handling requests
        public DentalOfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/dentaloffices/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DentalOfficeDetailDTO>> Get(Guid id)
        {
            // Implementation for getting a dental office by ID
            var query = new GetDentalOfficeDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return result;
        }

        // POST api/dentaloffices
        [HttpPost]
        public async Task<IActionResult> Post(CreateDentalOfficeDTO createDentalOfficeDTO)
        {
            var command = new CreateDentalOfficeCommand { Name = createDentalOfficeDTO.Name };
            var result = await _mediator.Send(command);
            return Ok();
        }


    }
}
