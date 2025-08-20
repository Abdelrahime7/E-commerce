using Domain.entities;

namespace Application.DTOs.Review
{
    public record ReviewRequest
    {
        public int Id { get; set; }
        public string? Descreption { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public int ItemID { get; set; }
       

    }

}
