using Domain.Interface;
using System;

namespace Domain.entities;

public class Invoice :IEntity,ISoftDelete
{
    public int Id { get; set; }
    public short Quantity   { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public int OrderID { get; set; }
    public int ItemID { get; set; }

    public decimal Total { get; set; }
    public  Item Item  { get; set; }

    public   Order Order { get; set; }
    public bool IsDeleted { get  ; set; }
}