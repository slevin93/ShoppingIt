using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Defines account types.
    /// </summary>
    public class AccountType
    {
        /// <summary>
        /// Gets or sets the account type id.
        /// </summary>
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Gets or sets the account type name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the account type description.
        /// </summary>
        public string Description { get; set; }
    
        public virtual ICollection<AssignedAccountType> AssignedAccountTypes { get; set; }
    }
}
