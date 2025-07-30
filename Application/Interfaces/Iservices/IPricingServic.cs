


using Application.DTOs.Item;
using Domain.entities;

namespace Application.Interfaces.Iservices
{
    public interface IPricingService
    {
            decimal CalculatePrice(Item item, int quantity); // Base price logic
            decimal ApplyDiscounts(decimal price, int Quantity, Customer customer); // Personalized discounts
            decimal CalculateTax(Item item, decimal netPrice); // Optional tax logic
            PriceDetailsDto GetPriceDetails(Item item, int quantity, Customer customer); // Full breakdown
       
    }

}
