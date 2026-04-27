using DentalManagementSystem.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DentalManagementSystem.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DentalManagementSystem.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalManagementSystem.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddTransient<IMediator, SimpleMediator>();
            services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, CreateDentalOfficeCommandHandler>();
            services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>, GetDentalOfficeDetailQueryHandler>();

            return services;
        }
    }
}
