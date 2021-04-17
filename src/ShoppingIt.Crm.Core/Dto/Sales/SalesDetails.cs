// <copyright file="SalesDetails.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Dto.Sales
{
    using System;

    /// <summary>
    /// Defines the sales details.
    /// </summary>
    public class SalesDetails
    {
        /// <summary>
        /// Gets or sets the sale id.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the payment type id.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the sales status id.
        /// </summary>
        public int SalesStatusId { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
