using eCommerce.Core.Dtos;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[!@#$%^&*]+").WithMessage("Password must contain at least one special character");

            RuleFor(x=>x.PersonName)
                .NotEmpty().WithMessage("Person Name is required")
                .Length(3, 50).WithMessage("Person Name must be between 3 and 50 characters");

            RuleFor(x=>x.Gender)
                .NotEmpty().WithMessage("Gender is required")
                .IsInEnum().WithMessage("Enter a valid Gender");    
        }
    }
}
