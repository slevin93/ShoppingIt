// <copyright file="Account.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines user account details.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets account id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets assigned company id.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets password salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets login attempts.
        /// </summary>
        public int LoginAttempt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether account locked.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets unlock date time.
        /// </summary>
        public DateTime? UnlockDateTime { get; set; }

        /// <summary>
        /// Gets or sets time stamp account was created.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the assigned account types.
        /// </summary>
        public virtual ICollection<AssignedAccountType> AssignedAccountTypes { get; set; }

        /// <summary>
        /// Gets or sets the sales.
        /// </summary>
        public virtual ICollection<Sale> Sales { get; set; }

        /// <summary>
        /// Gets or sets the company the account is assigned to.
        /// </summary>
        public virtual Company Company { get; set; }
    }
}
