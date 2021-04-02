// <copyright file="RegisterCompanyModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Company
{
    using System.Collections.Generic;
    using FluentValidation;
    using ShoppingIt.Crm.Core.Models.Account;

    /// <summary>
    /// The register company request model.
    /// </summary>
    public class RegisterCompanyModel : Validator
    {
        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the address line 3.
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the address line 4.
        /// </summary>
        public string AddressLine4 { get; set; }

        /// <summary>
        /// Gets or sets the list of user accounts.
        /// </summary>
        public List<RegisterModel> Accounts { get; set; }
    }

    /// <summary>
    /// Implement register company validation.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class RegisterCompanyValidator : AbstractValidator<RegisterCompanyModel>
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCompanyValidator"/> class.
        /// </summary>
        public RegisterCompanyValidator()
        {
            this.RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }
}
