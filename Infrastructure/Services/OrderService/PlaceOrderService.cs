using Application.DTOs.Order;
using Application.Interfaces.Iservices;


namespace Infrastructure.Services.OrderService
{
     
    public class PlaceOrderService : IIorderService
    {
        

        public Task<Guid> PlaceOrderAsync(OrderDto dto)
        {
           
           

            throw new NotImplementedException();
        }
    }
}
