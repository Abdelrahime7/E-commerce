using Application.DTOs.Item;
using Application.Interfaces.Iservices;
using Application.Interfaces.Specific;
using Domain.entities;
using Domain.Enums;
using Microsoft.Extensions.Logging;
using Stripe;
using System.Threading.Tasks;
using Customer = Domain.entities.Customer;

namespace Infrastructure.Services.PricingService
{
    public class PricingService : IPricingService
    {
        private readonly ILogger<PricingService> _logger;
        private IDisacountsRepository _countsRepository;

        public PricingService(ILogger<PricingService> logger,
            IDisacountsRepository countsRepository)
        {
            _logger = logger;
            _countsRepository = countsRepository;
        }

        public async Task<decimal> ApplyCustomerDiscounts(decimal Price,Customer customer)
        {


            decimal discount = 0m;
            _logger.LogInformation("Applying discounts for customer type {CustomerType}", customer.type);

            // Example: Loyalty-based discount
            if (customer.type == EnCustomerType.Premium)
            {
                var disValue = await _countsRepository.GetValuebytype("Premium");
                discount += Price * disValue; // 10% discount
            }
            else if (customer.type == EnCustomerType.Standard)
            {
                var disValue = await _countsRepository.GetValuebytype("Standard");

                discount += Price * disValue; // 5% discount
            }
            return discount;
        }

        public async Task<decimal> ApplyQuantityDiscounts(decimal Price, int Quantity)// Personalized discounts
        {
            decimal discount = 0m;
            _logger.LogInformation("Applying discounts for customer type {Quantity}", Quantity);
            var disValue = await _countsRepository.GetValuebytype("Bulk");

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
            var discount = ApplyCustomerDiscounts(item.Price, customer).Result;
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
