using Domain.Interface;

namespace Domain.entities;

public class Person:IEntity,ISoftDelete
{
    public int Id {  get; set; }
    public  string FName { get; set; }
    public  string  LName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public  User  User { get; set; } 
    public Customer Customer { get; set; }
    public bool IsDeleted { get ; set ; }
}