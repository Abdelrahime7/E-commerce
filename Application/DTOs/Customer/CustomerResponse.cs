namespace Application.DTOs.Customer
{
    public record CustomerRequest
    {
        public int ID;
        public int Point { get; set; }
        public int PersonID     { get; set; }
        public required string FName { get; set; }
        public required string LName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }


}