// <copyright file="ErrorDetails.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Api.Middleware.Exceptions
{
    using Newtonsoft.Json;

    /// <summary>
    /// Class to wrap error details.
    /// </summary>
    internal class ErrorDetails
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returns error details as json string.
        /// </summary>
        /// <returns>Returns <see cref="ErrorDetails"/> as json string.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
