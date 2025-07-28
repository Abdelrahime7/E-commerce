

namespace Application.Interfaces.Iservices
{
    public interface IPaymentService
    {
        Task AuthorizeAsync(Guid customerId, decimal amount);
    }

}
