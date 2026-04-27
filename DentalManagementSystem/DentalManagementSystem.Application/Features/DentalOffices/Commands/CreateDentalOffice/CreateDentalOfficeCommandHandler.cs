using DentalManagementSystem.Application.Contracts.Persistence;
using DentalManagementSystem.Application.Contracts.Repositories;
using DentalManagementSystem.Application.Exceptions;
using DentalManagementSystem.Application.Utilities;
using DentalManagementSystem.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    // The command handler for creating a new dental office, which implements IRequestHandler with the command type and return type of Guid.
    public class CreateDentalOfficeCommandHandler: IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        // The dependencies for the command handler, which include the dental office repository and the unit of work for managing transactions.
        private readonly IDentalOfficeRepository _dentalOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;

        // The constructor for the command handler, which takes the dependencies as parameters and assigns them to private fields.
        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository dentalOfficeRepository, IUnitOfWork unitOfWork)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        // The Handle method is responsible for processing the CreateDentalOfficeCommand. It creates a new DentalOffice entity using the name provided in the command, adds it to the repository, and commits the transaction. If any exceptions occur during this process, it rolls back the transaction and rethrows the exception.
        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            // Create a new DentalOffice entity (In Memory) using the name provided in the command. (Assuming the DentalOffice constructor takes a name as a parameter and generates a new Id internally.)
            var dentalOffice = new DentalOffice(command.Name);
            try
            {
                // Add the new dental office to the repository and commit the transaction.
                var result = await _dentalOfficeRepository.Add(dentalOffice);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                // If any exceptions occur, roll back the transaction and rethrow the exception.
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
