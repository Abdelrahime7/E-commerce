using Application.Moduels.Customer.Commands;
using FluentValidation;

namespace Application.Moduels.Customer.Validators
{

    public class DeleteCustomerCommandValidator : AbstractValidator<SoftDeleteCustomerCommand>
    {


        public DeleteCustomerCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");
          
        }

    }



}
