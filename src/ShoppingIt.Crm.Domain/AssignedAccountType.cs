// <copyright file="AssignedAccountType.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Defines the link between accounts and account types.
    /// </summary>
    public class AssignedAccountType
    {
        /// <summary>
        /// Gets or sets the assigned account type id.
        /// </summary>
        public int AssignedAccountTypeId { get; set; }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the account type id.
        /// </summary>
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// Gets or sets the account type.
        /// </summary>
        public virtual AccountType AccountType { get; set; }
    }
}
