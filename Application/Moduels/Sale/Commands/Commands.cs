using Application.DTOs.Sale;
using MediatR;


namespace Application.Moduels.Sale.Commands
{
    public record CreateSaleCommand(SaleDto saleDto) : IRequest<int>;
    public record UpdateSaleCommand(SaleResponse Response) : IRequest<SaleDto>;
    public record DeleteSaleCommand(int ID) : IRequest<bool>;
    public record SoftDeleteSaleCommand(int ID) : IRequest<bool>;


}
