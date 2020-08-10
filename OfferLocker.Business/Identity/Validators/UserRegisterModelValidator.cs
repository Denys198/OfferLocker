using FluentValidation;
using OfferLocker.Business.Identity.Models;

namespace OfferLocker.Business.Identity.Validators
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotNull();
            RuleFor(x => x.FullName)
                .NotNull();
        }
    }
}
