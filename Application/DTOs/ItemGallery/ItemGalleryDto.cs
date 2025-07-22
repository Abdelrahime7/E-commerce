using Domain.entities;

namespace Application.DTOs.ItemGallery
{
    public record ItemGalleryDto
    {
        public int ItemID { get; set; }
        public required string ImageLink { get; set; }

    }


}