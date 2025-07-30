using Application.DTOs.Item;
using Application.Interfaces.Iservices;
using Domain.entities;
using Domain.Enums;

namespace Application.Services.PricingService
{
    public class PricingService : IPricingService
    {
       
            public decimal ApplyDiscounts(decimal Price,int  Quantity, Customer customer)
        {
            decimal discount = 0m;

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

            return discount*Quantity;

        }

      

        public decimal CalculatePrice(Item item, int quantity)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

            return item.Price * quantity;
        }


        public decimal CalculateTax(Item item,decimal netprice)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (netprice < 0)
                throw new ArgumentOutOfRangeException("Net price cannot be negative.");

            return netprice * item.TaxRate;
        }


        public PriceDetailsDto GetPriceDetails(Item item,int quantity, Customer customer)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var basePrice = CalculatePrice(item, quantity);
            var discount = ApplyDiscounts(item.Price, quantity, customer);
            var netPrice = basePrice - discount;
            var tax = CalculateTax(item, netPrice);
            var finalPrice = netPrice + tax;

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
