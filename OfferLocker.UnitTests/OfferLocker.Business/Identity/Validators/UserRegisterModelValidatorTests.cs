using FluentAssertions;
using OfferLocker.Business.Identity.Validators;
using OfferLocker.UnitTests.Shared.Factories;
using Xunit;

namespace OfferLocker.UnitTests.OfferLocker.Business.Identity.Validators
{
    public class UserRegisterModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingValidInput_ThenResultShoulBeValid()
        {
            var model = UserRegisterModelFactory.Default();
            var validator = new UserRegisterModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenInvalidEmail_WhenHavingInvalidInput_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.WithEmailNull();
            var validator = new UserRegisterModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenInvalidName_WhenHavingInvalidInput_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.WithFullNameNull();
            var validator = new UserRegisterModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenNoPassword_WhenHavingInvalidInput_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.WithPasswordNull();
            var validator = new UserRegisterModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
        }
    }
}
