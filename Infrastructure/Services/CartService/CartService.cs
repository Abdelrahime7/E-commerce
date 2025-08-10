using Application.Interfaces.Iservices;
using Domain.Cart;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.CartService
{
    public class CartService :ICartService
    {
        private readonly ILogger<CartService> _logger;
        private readonly Cart _cart;
        public Cart cart => _cart;

       
            


        public CartService(ILogger<CartService> logger)
        {
            _logger = logger;
            _cart = new Cart();
        }


        public void AddItem(ItemDetaills itemDetaills)
        {
            _cart?.itemDetaills.Add(itemDetaills);
            _logger.LogInformation("Item added to cart: {@ItemDetails}", itemDetaills);
        }

        public List<ItemDetaills> GetItems()
        {
            var items = _cart?.itemDetaills.ToList() ?? new List<ItemDetaills>();
            _logger.LogInformation("Retrieved {Count} items from cart", items.Count);
            return items;
        }

        public decimal GetTotalAmount()
        {
            if (_cart != null && _cart.itemDetaills.Count > 0)
            {
                decimal total = _cart.itemDetaills.Sum(detail => detail.total);
                _logger.LogInformation("Calculated total amount: {Total}", total);
                return total;
            }

            _logger.LogWarning("Cart is null or empty when calculating total amount");
            return 0;
        }

        public void RemoveItem(Guid itemDetaillsID)
        {
            if (_cart != null)
            {
                var itemToRemove = _cart.itemDetaills.FirstOrDefault(i => i.Id == itemDetaillsID);
                if (!itemToRemove.Equals(default(ItemDetaills)))
                {
                    _cart.itemDetaills.Remove(itemToRemove);
                    _logger.LogInformation("Removed item from cart: {@ItemDetails}", itemToRemove);
                }
                else
                {
                    _logger.LogWarning("Attempted to remove item with ID {ItemId}, but it was not found", itemDetaillsID);
                }
            }
        }

        public void UpdateQuantity(Guid itemDetaillsID, int quantity)
        {
            if (_cart != null)
            {
                var itemToUpdate = _cart.itemDetaills.FirstOrDefault(i => i.Id == itemDetaillsID);
                if (!itemToUpdate.Equals(default(ItemDetaills)))
                {
                    itemToUpdate.Quantity = quantity;
                    _logger.LogInformation("Updated quantity for item {ItemId} to {Quantity}", itemDetaillsID, quantity);
                }
                else
                {
                    _logger.LogWarning("Attempted to update quantity for item {ItemId}, but it was not found", itemDetaillsID);
                }
            }
        }
    }

}
