using FluentValidation;
using OfferLocker.Business.Identity.Models;


namespace OfferLocker.Business.Identity.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotNull();
        }
    }
}
