using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using Domain.Cart;

namespace Infrastructure.Services.PyamentService
{
    public class CODPaymentService : ICODService
    {
        private readonly IOrderService _orderService;
     
        public CODPaymentService(IOrderService orderService)
        {
            
             _orderService = orderService;
        }
        public async Task InitiateAsync(Cart cart)
        {
           
        }

        
    }
}
