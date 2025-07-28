

using Application.DTOs.Order;

namespace Application.Interfaces.Iservices
{
    public interface IIorderService
    {
        Task<Guid> PlaceOrderAsync(OrderDto dto);
    }

}
