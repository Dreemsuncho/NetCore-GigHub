using FluentValidation;

namespace NetCore_GigHub.ViewModels
{
    public class ViewModelLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class VmLoginValidator : AbstractValidator<ViewModelLogin>
    {
        public VmLoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .MaximumLength(40)
                .WithMessage("Username too long");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MaximumLength(40)
                .WithMessage("Password too long");
        }
    }
}