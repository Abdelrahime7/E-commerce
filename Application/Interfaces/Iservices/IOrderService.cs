

using Application.DTOs.Order;
using Domain.entities;

namespace Application.Interfaces.Iservices
{
    public interface IOrderService
    {
        Task<Order> PlaceOrderAsync(OrderDto dto);
    }

}
