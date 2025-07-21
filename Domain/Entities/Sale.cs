using Domain.Interface;

namespace Domain.entities;

public class Sale:IEntity,ISoftDelete
{
    public  int Id { get; set; }
    public decimal TotalFees { get; set; }
    public int OrderId { get; set; }
    public required Order Order { get; set; }
    public bool IsDeleted { get; set; }
}