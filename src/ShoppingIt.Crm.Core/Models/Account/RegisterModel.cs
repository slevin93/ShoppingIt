// <copyright file="RegisterModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Account
{
    using FluentValidation;

    /// <summary>
    /// The register request model.
    /// </summary>
    public class RegisterModel : Validator
    {
        /// <summary>
        /// Gets or sets the company to assigned to user.
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

    /// <summary>
    /// Implement account validation.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class AccountValidator : AbstractValidator<RegisterModel>
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountValidator"/> class.
        /// </summary>
        public AccountValidator()
        {
            this.RuleFor(x => x.CompanyId).GreaterThan(0);

            this.RuleFor(x => x.Email).EmailAddress();

            this.RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
        }
    }
}
