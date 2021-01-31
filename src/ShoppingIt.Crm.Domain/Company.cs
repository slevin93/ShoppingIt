using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Gets or sets the company for each user.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the company address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the company address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the company address line 3.
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets the company address line 4.
        /// </summary>
        public string AddressLine4 { get; set; }

        /// <summary>
        /// The list of users assigned to this company.
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
