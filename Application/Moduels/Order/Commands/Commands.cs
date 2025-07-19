using Application.DTOs.Customer;
using Application.DTOs.Order;
using MediatR;

namespace Application.Moduels.Order.Commands
{
    public record CreateOrderCommand(OrderDto OrderDto ) : IRequest<int>;
    public record UpdateOrderCommand(OrderResponse Response) : IRequest<OrderDto>;
    public record DeleteOrderCommand(int ID) : IRequest<bool>;


}
