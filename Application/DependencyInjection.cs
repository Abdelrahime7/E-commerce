using Application.Mapper.CustomersProfile;
using Application.Moduels.Common.Behaviors;
using Application.Moduels.Customer.Handlers;
using Application.Moduels.Customer.Validators;
using Application.Moduels.User.Handlers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Mediatr:
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));
     services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(typeof(AuthenticateUserHandler).Assembly));

        //Auto Mapper :
        services.AddAutoMapper(typeof(CustomerMapping));

        //Fluent validation:
        services.AddValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();

        //Pibline Behavior:
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



        return services;
    }
}