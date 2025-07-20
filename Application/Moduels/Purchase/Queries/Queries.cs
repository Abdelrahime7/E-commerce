using Application.DTOs.Purchase;
using MediatR;


namespace Application.Moduels.Purchase.Queries
{
    public class Queries
    {
        public record GetPurchaseByIdQuery(int Id) : IRequest<PurchasHistoryDto>;
        public record GetAllPurchasesQuery : IRequest<IReadOnlyCollection<PurchasHistoryDto>>;

    }
}
