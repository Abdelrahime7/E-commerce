

namespace Application.Interfaces.Iservices
{
    public interface IPaymentService
    {
            Task<string> CreateCheckoutSessionAsync(decimal amount, string currency);

    }
}
