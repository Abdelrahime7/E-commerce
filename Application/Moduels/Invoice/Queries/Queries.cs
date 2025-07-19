using Application.DTOs.Invoice;
using MediatR;
namespace Application.Moduels.Invoice.Queries
{
    public class Queries
    {
        public record GetInvoiceByIdQuery(int Id) : IRequest<InvoiceDto>;
        public record GetAllInvoiceQuery : IRequest<IReadOnlyCollection<InvoiceDto>>;

    }
}
