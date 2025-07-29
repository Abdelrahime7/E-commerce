using Application.Interfaces.Iservices;

namespace Application.Services.PyamentService
{
    public class PayementServic : IPaymentService
    {
        public Task AuthorizeAsync(Guid customerId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
