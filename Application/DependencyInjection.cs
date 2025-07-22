using Application.Mapper.CustomersProfile;
using Application.Moduels.User.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));

        services.AddAutoMapper(typeof(CustomerMapping));

       

        return services;
    }
}