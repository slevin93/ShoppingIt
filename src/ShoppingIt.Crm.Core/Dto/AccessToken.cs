// <copyright file="AccessToken.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Dto
{
    using System;

    /// <summary>
    /// Define user access token.
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// Gets or sets the bearer token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the token expiry date time.
        /// </summary>
        public DateTime Expiry { get; set; }
    }
}
