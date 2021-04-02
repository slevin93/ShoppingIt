// <copyright file="LoginModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Account
{
    using FluentValidation;

    /// <summary>
    /// The login request model.
    /// </summary>
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

    /// <summary>
    /// Implement the login validation.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class LoginValidator : AbstractValidator<LoginModel>
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginValidator"/> class.
        /// </summary>
        public LoginValidator()
        {
            this.RuleFor(x => x.Email).EmailAddress();

            this.RuleFor(x => x.Password).NotEmpty().NotNull();
        }
    }
}
