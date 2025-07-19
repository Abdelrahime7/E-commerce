using Application.DTOs.Sale;
using MediatR;


namespace Application.Moduels.Sale.Queries
{
    public class Queries
    {
        public record GetSaleByIdQuery(int Id) : IRequest<SaleDto>;
    }
}
