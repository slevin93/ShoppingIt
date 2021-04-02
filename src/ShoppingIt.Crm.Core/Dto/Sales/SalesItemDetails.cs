// <copyright file="SalesItemDetails.cs" company="ShoppingIt Ltd">
// Copyright (c) ShoppingIt Ltd. All rights reserved.
// </copyright>

namespace ShoppingIt.Crm.Core.Dto.Sales
{
    /// <summary>
    /// Defines the item of sale.
    /// </summary>
    public class SalesItemDetails
    {
        /// <summary>
        /// Gets or sets sale item id.
        /// </summary>
        public int SaleItemId { get; set; }

        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets price of sale.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets vat.
        /// </summary>
        public decimal Vat { get; set; }

        /// <summary>
        /// Gets or sets the quantity of items.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets total item (<see cref="Price"/> * <see cref="Quantity"/>).
        /// </summary>
        public decimal Total => this.Price * this.Quantity;
    }
}
