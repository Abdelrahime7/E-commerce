
using Application.DTOs.Purchase;
using MediatR;


namespace Application.Moduels.Purchase.Commands
{
    public record CreatePurchaseCommand(PurchasHistoryDto purhcaseDto) : IRequest<int>;
    public record UpdatePurchaseCommand(PurchasHistoryRequest request) : IRequest<PurchasHistoryDto>;
    public record DeletePurchaseCommand(int ID ) : IRequest<bool>;
    public record SoftDeletePurchaseCommand(int ID) : IRequest<bool>; 


}
