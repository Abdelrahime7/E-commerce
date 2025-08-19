namespace Application.DTOs.Invoice
{
    public record InvoiceRequest
    {
     public int Id { get; set; }
    public    short Quantity { get; set; } 
    public decimal Price { get; set; }
     public DateTime Date {  get; set; }
      public int OrderID { get; set; }
      public int ItemID { get; set; }
    }


}