using Application.DTOs.ItemGallery;
using MediatR;


namespace Application.Moduels.ItemGallery.Commands
{

        
    public record CreateItemGalleryCommand(ItemGalleryDto itemGalleryDto) : IRequest<int>;
    public record UpdateItemGalleryCommand(ItemGalleryRequest request) : IRequest<ItemGalleryDto>;

    public record DeleteItemGalleryCommand(int ID) : IRequest<bool>;
    public record SoftDeleteItemGalleryCommand(int ID) : IRequest<bool>;


}
