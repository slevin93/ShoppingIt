using FluentValidation;
using ShoppingIt.Crm.Core.Models.Account;
using ShoppingIt.Crm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Core.Models.Company
{
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

    public class RegisterCompanyValidator : AbstractValidator<RegisterCompanyModel>
    {
        public RegisterCompanyValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }
}
