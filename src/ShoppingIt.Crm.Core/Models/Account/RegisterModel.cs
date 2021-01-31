using FluentValidation;

namespace ShoppingIt.Crm.Core.Models.Account
{
    public class RegisterModel : Validator
    {
        /// <summary>
        /// Define the company to assigned to user.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        public string ConfirmPassword { get; set; }
    }

    public class AccountValidator : AbstractValidator<RegisterModel>
    {
        public AccountValidator()
        {
            RuleFor(x => x.CompanyId).GreaterThan(0);

            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
        }
    }
}
