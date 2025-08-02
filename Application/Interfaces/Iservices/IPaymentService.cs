

namespace Application.Interfaces.Iservices
{
    public interface IPaymentService
    {
        Task<string> CreateCheckoutSessionAsync(long amount, string currency);
    }

}
