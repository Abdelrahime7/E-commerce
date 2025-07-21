using Domain.Interface;

namespace Domain.entities;

public class ItemGallery:IEntity,ISoftDelete
{
    public int  Id  { get; set; }
    public int ItemID{ get; set; }

    public required Item Item{ get; set; }
    public required string ImageLink { get; set; }
    public bool IsDeleted { get; set; }
}