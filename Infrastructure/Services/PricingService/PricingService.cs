using Application.DTOs.Item;
using Application.Interfaces.Iservices;
using Domain.entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.PricingService
{
    public class PricingService : IPricingService
    {
        private readonly ILogger<PricingService> _logger;

        public PricingService(ILogger<PricingService> logger)
        {
            _logger = logger;
        }

        public decimal ApplyDiscounts(decimal Price,int  Quantity, Customer customer)
        {
           

            decimal discount = 0m;
            _logger.LogInformation("Applying discounts for customer type {CustomerType} and quantity {Quantity}", customer.type, Quantity);

            // Example: Loyalty-based discount
            if (customer.type == EnCustomerType. Premium)
            {
              
                discount +=Price * 0.10m; // 10% discount
            }
            else if (customer.type == EnCustomerType.Standard)
            {
                discount += Price * 0.05m; // 5% discount
            }
            

            // Example: Bulk discount
            if (Quantity >= 10)
            {
                discount += Price * 0.03m; // Additional 3% discount
            }
            _logger.LogDebug("Base price: {Price}, Calculated discount: {Discount}", Price, discount * Quantity);
            return discount*Quantity;
            
        }

      

        public decimal CalculatePrice(Item item, int quantity)
        {
            _logger.LogInformation("Calculating base price for item {ItemId} with quantity {Quantity}", item.Id, quantity);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

            return item.Price * quantity;
        }


        public decimal CalculateTax(Item item,decimal netprice)
        {
            _logger.LogInformation("Calculating tax for item {ItemId} with net price {NetPrice}", item.Id, netprice);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (netprice < 0)
                throw new ArgumentOutOfRangeException("Net price cannot be negative.");

            _logger.LogDebug("Tax rate: {TaxRate}, Calculated tax: {Tax}", item.TaxRate, netprice * item.TaxRate);

            return netprice * item.TaxRate;
        }


        public PriceDetailsDto GetPriceDetails(Item item,int quantity, Customer customer)
        {
            _logger.LogInformation("Generating price details for item {ItemId}, quantity {Quantity}, customer {CustomerId}", item.Id, quantity, customer.Id);
           

            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var basePrice = CalculatePrice(item, quantity);
            var discount = ApplyDiscounts(item.Price, quantity, customer);
            var netPrice = basePrice - discount;
            var tax = CalculateTax(item, netPrice);
            var finalPrice = netPrice + tax;
            _logger.LogDebug("BasePrice: {BasePrice}, Discount: {Discount}, NetPrice: {NetPrice}, Tax: {Tax}, FinalPrice: {FinalPrice}",
               basePrice, discount, netPrice, tax, finalPrice);

            return new PriceDetailsDto
            {
                UnitPrice = item.Price,
                Quantity = quantity,
                Discount = discount,
                Tax = tax,
                FinalPrice = finalPrice
            };
        }

    }
}
