using FluentValidation;

namespace NetCore_GigHub.ViewModels
{
    public class ViewModelRegister
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }

    public class VmRegisterValidator : AbstractValidator<ViewModelRegister>
    {
        public VmRegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email field is not a valid email")
                .MaximumLength(40)
                .WithMessage("Email too long, we dosn't work with people with long emails!");

            RuleFor(x => x.Username)
                   .NotEmpty()
                   .WithMessage("Username is required")
                   .MaximumLength(40)
                   .WithMessage("Username too long");

            RuleFor(x => x.Password)
                   .NotEmpty()
                   .WithMessage("Password is required");

            RuleFor(x => x.PasswordRepeat)
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match");
        }
    }
}
