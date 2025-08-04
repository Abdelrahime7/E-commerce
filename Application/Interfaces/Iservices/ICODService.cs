


using Domain.Cart;

namespace Application.Interfaces.Iservices
{
    // COD :cash on delivery 
    public interface ICODService   
    {
      Task  InitiateAsync(Cart cart);
      Task<bool> ConfirmAsync(int id);


    }
}
