
using Domain.Cart;
using FluentValidation;

namespace Application.CartValidation
{
    public partial class ClientInfoValidator : AbstractValidator<ClientInfo>
    {


        public ClientInfoValidator()
        {
            RuleFor(C => C.Fname).NotEmpty().WithMessage("Fname is required");
            RuleFor(C => C.LName).NotEmpty().WithMessage("LName is required");
            RuleFor(C => C.Email).NotEmpty().EmailAddress().WithMessage("Email is required");
            RuleFor(C => C.Phone).NotEmpty().WithMessage("Phone is required");
        }

    }
}

