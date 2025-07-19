using Application.DTOs.Order;
using MediatR;

namespace Application.Moduels.Order.Queries
{
    public class Queries
    {
        public record GetOrderByIdQuery(int Id) : IRequest<OrderDto>;
        public record GetAllOrderQuery : IRequest<IReadOnlyCollection<OrderDto>>;

    }
}
