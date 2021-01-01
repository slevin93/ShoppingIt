using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Models.Account
{
    public class AccountRequestModel : Validator
    {
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

    public class AccountValidator : AbstractValidator<AccountRequestModel>
    {
        public AccountValidator()
        {
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
        }
    }
}
