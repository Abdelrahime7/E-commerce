using Domain.Enums;
using Domain.Interface;
using System.Collections.Generic;

namespace Domain.entities;

public class Customer :IEntity,ISoftDelete
{
    public int Id { get; set; }
    public  Person   Person { get; set; }
    public int Point {  get; set; }
    public EnCustomerType type { get; set; }
    public int PersonID { get; set; }
    public ICollection<PurchaseHistory> PurchasesHistory { get; set; }=new List<PurchaseHistory>();
    public bool IsDeleted { get; set; }
}