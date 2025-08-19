using Application.DTOs.Item;
using MediatR;

namespace Application.Moduels.Item.Commands
{
    public record CreateItemCommand(ItemDto itemDto) : IRequest<int>;
    public record UpdateItemCommand(ItemRequest Request) : IRequest<ItemDto>;
    public record DeleteItemCommnd(int ID): IRequest<bool>;
    public record SoftDeleteItemCommand(int ID) : IRequest<bool>;

}
