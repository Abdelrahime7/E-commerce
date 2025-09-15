using Application.Interface;
using Application.Interfaces.Generic;
using Application.Interfaces.Iservices;
using Application.Interfaces.Specific.IunitOW;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;
using Infrastructure.Repository.specific_Repo;
using Infrastructure.Services.CartService;
using Infrastructure.Services.InventoryService;
using Infrastructure.Services.OrderService;
using Infrastructure.Services.PricingService;
using Infrastructure.Services.PyamentService;
using Infrastructure.Services.ShippingService;
using Infrastructure.Services.TokenService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

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
        services.AddScoped<IGetRols, GetRols>();


        // UOW 
        services.AddScoped<ICustomerUnitOfWork, CustomerUnitOFwork>();
        services.AddScoped<IItemUnitOfWork, ItemUnitOFwork>();
        services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
        services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

        //Iservices
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPricingService, PricingService>();
        services.AddScoped<IPaymentService, StripePaymentService>();
        services.AddScoped<ICODService, CODPaymentService>();
        services.AddScoped<IShippingService, ShippingService>();
        services.AddScoped<IInventoryService, ManageInventoryService>();
       services.AddScoped<ITokenService,TokenServic>();











        return services;
    }
}