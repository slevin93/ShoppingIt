// <copyright file="AccountAuthDetails.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Dto.Accounts
{
    /// <summary>
    /// Define account details with credentials.
    /// </summary>
    public class AccountAuthDetails : AccountDetails
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        public string Salt { get; set; }
    }
}
