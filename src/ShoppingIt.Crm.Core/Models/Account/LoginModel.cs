using FluentValidation;

namespace ShoppingIt.Crm.Core.Models.Account
{
    public class LoginModel : Validator
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }

    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).NotEmpty().NotNull();
        }
    }
}
