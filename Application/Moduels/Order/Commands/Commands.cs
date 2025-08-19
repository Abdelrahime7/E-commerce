using Application.DTOs.Order;
using MediatR;

namespace Application.Moduels.Order.Commands
{
    public record CreateOrderCommand(OrderDto OrderDto ) : IRequest<int>;
    public record UpdateOrderCommand(OrderRequest Request) : IRequest<OrderDto>;
    public record DeleteOrderCommand(int ID) : IRequest<bool>;
    public record SoftDeleteOrderCommand(int ID) : IRequest<bool>;



}
