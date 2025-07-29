using Application.Interfaces.Iservices;
using Domain.entities;

namespace Application.Services.ShippingService
{
    public class ShippingService : IShippingService
    {
        public Task ScheduleShipmentAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
