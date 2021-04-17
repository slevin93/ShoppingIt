// <copyright file="UpdateSaleItemModel.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Models.Sales
{
    /// <summary>
    /// Represents sale items to update.
    /// </summary>
    public class UpdateSaleItemModel
    {
        /// <summary>
        /// Gets or sets sale item id.
        /// </summary>
        public int SaleItemId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of items.
        /// </summary>
        public int Quantity { get; set; }
    }
}
