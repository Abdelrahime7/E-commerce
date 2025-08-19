using Application.DTOs.Invoice;
using MediatR;


namespace Application.Moduels.Invoice.Commands
{
    public record CreateInvoiceCommand(InvoiceDto Dto) : IRequest<int>;
    public record UpdateInvoiceCommand(InvoiceRequest Request) : IRequest<InvoiceDto>;
    public record DeleteInvoiceCommand(int ID):IRequest<bool>;
    public record SoftDeleteInvoiceCommand(int ID) : IRequest<bool>;


}
