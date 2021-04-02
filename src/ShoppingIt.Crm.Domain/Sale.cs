// <copyright file="Sale.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines sales.
    /// </summary>
    public class Sale
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
        /// Gets or sets the total.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets total items sold.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets time stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the payment type.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the sales status id.
        /// </summary>
        public int SalesStatusId { get; set; }

        /// <summary>
        /// Gets or sets account.
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// Gets or sets the sales items.
        /// </summary>
        public virtual ICollection<SaleItem> SaleItems { get; set; }

        /// <summary>
        /// Gets or sets the sale status.
        /// </summary>
        public virtual SalesStatus SalesStatus { get; set; }

        /// <summary>
        /// Gets or sets the payment type.
        /// </summary>
        public virtual PaymentType PaymentType { get; set; }
    }
}
