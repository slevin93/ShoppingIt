using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingIt.Crm.Domain
{
    /// <summary>
    /// Gets or sets products.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets sale price, 
        /// this will be the price the customer pays.
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the whole sale price,
        /// this will be the price we pay.
        /// </summary>
        public decimal WholePrice { get; set; }

        /// <summary>
        /// Gets or sets if we pay vat on this product.
        /// </summary>
        public bool IsVattable { get; set; }

        /// <summary>
        /// Gets or sets the amount we have in stock.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the link to the whole seller where we buy.
        /// </summary>
        public string WholeSaleLink { get; set; }

        /// <summary>
        /// Gets or sets the linked picture as an array.
        /// </summary>
        public string PictureLink { get; set; }

        /// <summary>
        /// Gets or sets if the product is active or not.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
