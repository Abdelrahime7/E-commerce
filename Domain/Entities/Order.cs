using Domain.Enums;
using Domain.Interface;
using System.Collections.Generic;

namespace Domain.entities;

public class Order:IEntity
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Total {  get; set; }
    public int CustomerId { get; set; }

     public required Customer Customer { get; set; }
    public required PurchaseHistory PurchaseHistory { get; set; }
    public required Sale Sale { get; set; }


    public ICollection<Invoice>  invoices { get; set; }=new List<Invoice>();
}