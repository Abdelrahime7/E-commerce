

using Domain.entities;

namespace Application.Interfaces.Iservices
{
    public interface IShippingService
    {
        Task ScheduleShipmentAsync(Order order);
    }

}
