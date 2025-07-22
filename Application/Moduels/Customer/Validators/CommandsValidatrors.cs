using Application.Moduels.Customer.Commands;
using FluentValidation;

namespace Application.Moduels.Customer.Validators
{
    public class CrateCommandValidator:AbstractValidator<CreateCustomerCommand>
    {

        
        public CrateCommandValidator()
        {
            RuleFor(C => C.customerDto.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.customerDto.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.customerDto.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.customerDto.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");

        }



    }

    public class UpdateCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {


        public UpdateCommandValidator()
        {
            RuleFor(C => C.Response.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");
            RuleFor(C => C.Response.FName).NotEmpty().WithMessage("first name is required");
            RuleFor(C => C.Response.LName).NotEmpty().WithMessage("last name is required");
            RuleFor(C => C.Response.Phone).NotEmpty().WithMessage("phone is required");
            RuleFor(C => C.Response.Email).NotEmpty().WithMessage("Email is required").
                EmailAddress().WithMessage("wrong Email format");

        }



    }

    public class DeleteCommandValidator : AbstractValidator<SoftDeleteCustomerCommand>
    {


        public DeleteCommandValidator()
        {
            RuleFor(C => C.ID).NotEqual(0).NotEmpty().WithMessage("ID is required");
          
        }

    }



}
