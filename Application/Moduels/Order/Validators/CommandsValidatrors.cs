using Application.Moduels.Order.Commands;
using Domain.Enums;
using FluentValidation;

namespace Application.Moduels.Order.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateOrderCommand>
    {

        //public OrderStatus Status { get; set; }
        //public decimal Total { get; set; }
        //public int CustomerId { get; set; }

        //public IEnumerable<Domain.entities.Invoice> invoices = [];



        public CrateCommandValidator()
        {
            RuleFor(C => C.OrderDto.Status).NotEmpty().WithMessage("Order Status is required");
            RuleFor(C => C.OrderDto.Total).NotEmpty().WithMessage("Total is required");
            RuleFor(C => C.OrderDto.CustomerId).NotEmpty().WithMessage("Customer Id is required");
         
        }



    }

    public class UpdateCommandValidatror : AbstractValidator<UpdateOrderCommand>
    {


        public UpdateCommandValidatror()
        {
            RuleFor(C => C.Response.Id).NotEmpty().WithMessage("Order id  is required");
            RuleFor(C => C.Response.Status).NotEmpty().WithMessage("Order Status is required");
            RuleFor(C => C.Response.Total).NotEmpty().WithMessage("Total is required");
            RuleFor(C => C.Response.CustomerId).NotEmpty().WithMessage("Customer Id is required");


        }



    }

    public class DeleteCommandValidator : AbstractValidator<SoftDeleteOrderCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");

        }

    }

}
