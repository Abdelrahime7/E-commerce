using Application.DTOs.Customer;
using Application.DTOs.ItemGallery;
using MediatR;


namespace Application.Moduels.ItemGallery.Commands
{

        
    public record CreateItemGalleryCommand(ItemGalleryDto itemGalleryDto) : IRequest<int>;
    public record UpdateItemGalleryCommand(ItemGalleryResponse Response) : IRequest<ItemGalleryDto>;

    public record DeleteItemGalleryCommand(int ID) : IRequest<bool>;

}
