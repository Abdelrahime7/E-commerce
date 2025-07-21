using Domain.Enums;
using Domain.Interface;

namespace Domain.entities;

public class User:IEntity,ISoftDelete
{
    public int Id { get; set; }
    public string  UserName  { get; set; }
    public string  Password { get; set; } 
    public  bool IsAdmin { get; set; }
    public bool IsGuest { get; set; }
    
    public  int PersonID    { get; set; }
    public EnPermission EnPermission { get; set; }

    public required Person Person { get; set; }
    public bool IsDeleted { get;set; }
}