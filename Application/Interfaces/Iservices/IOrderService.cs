

using Application.DTOs.Order;
using Domain.entities;

namespace Application.Interfaces.Iservices
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(OrderDto dto);
        Task<OrderDto> GetOrderByID(int ID);
    }

}
