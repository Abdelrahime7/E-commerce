using Application.Interfaces.Specific.IunitOW;
using Application.Mapper.CustomersProfile;
using Application.Moduels.Order.Handlers;
using Domain.entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Conf =>
        {
            Conf.RegisterServicesFromAssemblies(typeof(CreateOrderHandler).Assembly);

        }
        );
        services.AddAutoMapper(typeof(CustomerMapping));
        


        return services;
    }
}