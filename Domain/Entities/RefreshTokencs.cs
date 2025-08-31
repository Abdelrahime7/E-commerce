using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Domain.Entities
{
    public class RefreshToken : IEntity
    {
       
            public int Id { get; set; }
            public string Token { get; set; }
            public int UserId { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ExpiryDate { get; set; }
            public DateTime RevockedDate { get; set; }
            public bool IsRevoked { get; set; }
            public string? DeviceInfo { get; set; } // Optional
            public  bool IsDeleted { get; set ; }
    }
}
