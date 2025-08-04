using Application.DTOs.Order;
using Application.Interfaces.Iservices;
using Domain.entities;


namespace Infrastructure.Services.OrderService
{
     
    public class PlaceOrderService : IOrderService
    {
        

        public Task<Order> PlaceOrderAsync(OrderDto dto)
        {
           
           

            throw new NotImplementedException();
        }
    }
}
