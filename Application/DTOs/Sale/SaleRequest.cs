namespace Application.DTOs.Sale
{
    public record SaleRequest
    {
        public int Id { get; set; }
        public decimal TotalFees { get; set; }
        public int OrderId { get; set; }
    }

}
