// <copyright file="AccountType.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Domain
{
    using System.Collections.Generic;

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

        /// <summary>
        /// Gets or sets the assigned account types.
        /// </summary>
        public virtual ICollection<AssignedAccountType> AssignedAccountTypes { get; set; }
    }
}
