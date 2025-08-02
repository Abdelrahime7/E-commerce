using Application.Interfaces.Iservices;

namespace Infrastructure.Services.PyamentService
{
    public class StripPayementServic : IPaymentService
    {
        public Task AuthorizeAsync(Guid customerId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateCheckoutSessionAsync(long amount, string currency)
        {
            throw new NotImplementedException();
        }
    }
}
