using Application.DTOs.ItemGallery;
using MediatR;


namespace Application.Moduels.ItemGallery.Queries
{
    public class Queries
    {
        public record GetItemGalleryByIdQuery(int Id) : IRequest<ItemGalleryDto>;
    }
}
