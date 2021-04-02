// <copyright file="SaleModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Sales
{
    /// <summary>
    /// Defines order details.
    /// </summary>
    public class SaleModel
    {
        /// <summary>
        /// Gets or sets the account to add the order to.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets defines payment type.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets define sales status.
        /// </summary>
        public int SaleStatusId { get; set; }

        /// <summary>
        /// Gets or sets the products assigned to the sale record.
        /// </summary>
        public SaleItemModel[] Items { get; set; }
    }
}
