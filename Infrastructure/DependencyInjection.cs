using Application.Interface;
using Application.Interfaces.Generic;
using Application.Interfaces.Specific.IunitOW;
using Domain.Interfaces.Generic;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;
using Infrastructure.Repository.specific_Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DefaultConnection"];

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        //Register your services here
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ICustomerRepository,CustomerRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemGalleryRepository, ItemGalleryRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPersonRepository,PersonRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        

        services.AddScoped<ICustomerUnitOfWork, CustomerUnitOFwork>();
        
        return services;
    }
}