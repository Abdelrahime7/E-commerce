using Domain.Interface;

namespace Domain.entities;

public class Inventory:IEntity ,ISoftDelete
{
    public int Id { get; set; }
    public int  InventoryDevision  { get; set; }
    public int ItemQuantity { get; set; }
    public int ItemID { get; set; }
    public  Item  Item { get; set; }
    public bool IsDeleted { get ; set ; }
}