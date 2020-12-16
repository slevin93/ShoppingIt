using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Defines the item of sale.
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// Gets or sets sale item id.
        /// </summary>
        public int SaleItemId { get; set; }

        /// <summary>
        /// Gets or sets sale id.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        public int ProductId { get; set; }

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
        /// Gets or sets total item (<see cref="Price"/> * <see cref="Quantity"/>).
        /// </summary>
        public decimal Total { get; set; }

        public virtual Product Product { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
