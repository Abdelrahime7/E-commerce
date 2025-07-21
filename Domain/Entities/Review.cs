using Domain.Interface;
using System;

namespace Domain.entities;

public class Review:IEntity,ISoftDelete
{
    public int Id { get; set; }
    public string  Descreption { get; set; }
    public DateTime Date { get; set; }

    public int CustomerId { get; set; }
    public int ItemID { get; set; }
    public  Customer Customer { get; set; }
    public   Item Item { get; set; }
    public bool IsDeleted { get; set ; }
}