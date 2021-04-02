// <copyright file="AccountDetails.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Dto.Accounts
{
    using System;

    /// <summary>
    /// Define account details without credentials.
    /// </summary>
    public class AccountDetails
    {
        /// <summary>
        /// Gets or sets account id.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the assigned company id.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the login attempt.
        /// </summary>
        public int LoginAttempt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is locked.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the unlock date time.
        /// </summary>
        public DateTime? UnlockDataTime { get; set; }
    }
}
