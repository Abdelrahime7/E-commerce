using Application.DTOs.Item;
using MediatR;


namespace Application.Moduels.Item.Queries
{
    public class Queries
    {
        public record GetItemByIdQuery(int Id) : IRequest<ItemDto>;
        public record GetAllItemsQuery : IRequest<IReadOnlyCollection<ItemDto>>;

    }
}
