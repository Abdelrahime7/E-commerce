

using Application.DTOs.Order;
using Domain.entities;

namespace Application.Interfaces.Iservices
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(OrderDto dto);
        Task<OrderDto> GetOrderByIDAsync(int ID);
        Task<OrderDto> UpdateOrderAsync(OrderRequest response);
        Task<bool> SoftDeleteOrderAsync(int ID);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    }

}
