// <copyright file="SaleItemModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Sales
{
    /// <summary>
    /// Contains sale time details.
    /// </summary>
    public class SaleItemModel
    {
        /// <summary>
        /// Gets or sets the product id to add to sale.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the amount of products for order.
        /// </summary>
        public int Quantity { get; set; }
    }
}
