using Application.Moduels.Customer.Commands;
using FluentValidation;

namespace Application.Moduels.Customer.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {



        public  CreateCustomerCommandValidator()
        {


            RuleFor(C => C.customerDto.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.customerDto.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.customerDto.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.customerDto.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");

        }



    }



}
