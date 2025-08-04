using Application.Interfaces.Iservices;
using Domain.Cart;

namespace Infrastructure.Services.CartService
{
    public  class CartService : ICartService
    {


        private Cart? _cart;
        public Cart? cart { get => _cart; }

        public CartService()
        {
            _cart = new Cart();
          
        }



     


        public void AddItem(ItemDetaills itemDetaills)
        {
            if ( _cart !=null)
            {
                _cart.itemDetaills.Add(itemDetaills);
            }
            
        }

        public List<ItemDetaills> GetItems()
        {
           
                return _cart.itemDetaills.ToList();
            
        }

        public decimal GetTotalAmount()
        {
            if (_cart != null)
            {
                if (_cart.itemDetaills.Count > 0)
                {

                    decimal total = 0;
                    var itemDetails = _cart.itemDetaills;
                    foreach (var Detail in itemDetails)
                    {
                        total += Detail.total;
                    }
                    return total;
                }
            }
            return 0;
        }

        public void RemoveItem(Guid itemDetaillsID)
        {
            if (_cart != null)
            {
                ItemDetaills itemToRemove = _cart.itemDetaills.FirstOrDefault(i => i.Id == itemDetaillsID);
                if (!itemToRemove.Equals(default(ItemDetaills)))
                {
                    _cart.itemDetaills.Remove(itemToRemove);
                }
               
            }

        }

        public void UpdateQuantity(Guid itemDetaillsID, int quantity)
        {
            if (_cart != null)
            {
                ItemDetaills itemToUpdate = _cart.itemDetaills.FirstOrDefault(i => i.Id == itemDetaillsID);
                if (!itemToUpdate.Equals(default(ItemDetaills)))
                {
                   itemToUpdate.Quantity=quantity;
                }

            }
        }
    }
}
