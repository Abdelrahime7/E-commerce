
using Domain.Cart;

namespace Application.Interfaces.Iservices
{
    public interface ICartService
    {

        void AddItem(ItemDetaills itemDetaills);
        void RemoveItem(Guid itemDetaillsID );
        void UpdateQuantity(Guid itemDetaillsID, int quantity);
        List<ItemDetaills> GetItems();
        decimal GetTotalAmount();

        Cart cart { get; }
    }

}
