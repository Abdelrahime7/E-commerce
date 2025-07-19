using Application.DTOs.Customer;
using Application.DTOs.Invoice;
using MediatR;


namespace Application.Moduels.Invoice.Commands
{
    public record CreateInvoiceCommand(InvoiceDto invoiceDto) : IRequest<int>;
    public record UpdateInvoiceCommand(InvoiceResponse Response) : IRequest<InvoiceDto>;
    public record DeleteInvoiceCommand(int ID):IRequest<bool>;

}
