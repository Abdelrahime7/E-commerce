using Domain.Enums;
using Domain.Interface;
using System;

namespace Domain.entities;

public class Item:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime ProdDate { get; set; }
    public UnitTypes UnitType { get; set; }

    public  Inventory Inventory {  get; set; }
    public ItemGallery  ItemGallery { get; set; }
    
   
}